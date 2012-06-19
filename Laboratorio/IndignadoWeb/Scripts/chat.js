/*

Copyright (c) 2009 Anant Garg (anantgarg.com | inscripts.com)

This script may be used for non-commercial purposes only. For any
commercial purposes, please contact the author at 
anant.garg@inscripts.com

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

*/

var windowFocus = true;
var username;
var chatHeartbeatCount = 0;
var minChatHeartbeat = 1000;
var maxChatHeartbeat = 3000;
var chatHeartbeatTime = minChatHeartbeat;
var originalTitle;
var blinkOrder = 0;

var chatboxFocus = new Array();
var newMessages = new Array();
var newMessagesWin = new Array();
var chatBoxes = new Array();
var usersNicks = new Array();

$(document).ready(function(){
	originalTitle = document.title;
	startChatSession();

	$([window, document]).blur(function(){
		windowFocus = false;
	}).focus(function(){
		windowFocus = true;
		document.title = originalTitle;
	});
    
    if ($.cookie('users_online_minimized') && $.cookie('users_online_minimized') == '0') {  
		$('#UsersOnline .UsersOnlineContent').css('display','block');
		$("#UsersOnline .UsersOnlineContent").scrollTop($("#UsersOnline .UsersOnlineContent")[0].scrollHeight);
	} else {
		$('#UsersOnline .UsersOnlineContent').css('display','none');
	}
    
});

function UpdateUsersOnline(users, usersCount) {
    if (usersCount == 1)
        $("#UsersOnlineTitle").html('Chat - <b>'+usersCount+'</b> user online');
    else 
        $("#UsersOnlineTitle").html('Chat - <b>'+usersCount+'</b> users online');
        
    $.each(users, function(i,user){
        if (user.active) {
            if ($("#user_online_"+user.id).length <= 0)
                $("#UsersOnlineList").append('<li id="user_online_'+user.id+'"><a href="javascript:void(0)" onclick="javascript:chatWith(\''+user.nick+'\', '+user.id+')">'+user.nick+'</a></li>');
            usersNicks[user.id] = user.nick;
        }
        else {
            $('#user_online_'+user.id).remove();
        }
    });
}

function restructureChatBoxes() {
	align = 0;
	for (x in chatBoxes) {
		chatboxroomid = chatBoxes[x];

		if ($("#chatbox_"+chatboxroomid).css('display') != 'none') {
			if (align == 0) {
				$("#chatbox_"+chatboxroomid).css('right', '20px');
			} else {
				width = (align)*(225+7)+20;
				$("#chatbox_"+chatboxroomid).css('right', width+'px');
			}
			align++;
		}
	}
}

function chatWith(chatuser, chatuserid) {
    $.ajax({
      url: "/Chat/InitChatBox",
      data: "userId="+chatuserid,
      cache: false,
      dataType: "json",
      success: function(data) {
        createChatBox(data.title, data.id);
        $("#chatbox_"+data.id+" .chatboxtextarea").focus();
    }});
}

function createChatBox(chatboxtitle,chatboxroomid,minimizeChatBox) {
	if ($("#chatbox_"+chatboxroomid).length > 0) {
		if ($("#chatbox_"+chatboxroomid).css('display') == 'none') {
			$("#chatbox_"+chatboxroomid).css('display','block');
			restructureChatBoxes();
		}
		$("#chatbox_"+chatboxroomid+" .chatboxtextarea").focus();
		return;
	}

	$(" <div />" ).attr("id","chatbox_"+chatboxroomid)
	.addClass("chatbox")
	.html('<div class="chatboxhead"><div class="chatboxtitle">'+chatboxtitle+'</div><div class="chatboxoptions"><a href="javascript:void(0)" onclick="javascript:toggleChatBoxGrowth(\''+chatboxroomid+'\')">-</a> <a href="javascript:void(0)" onclick="javascript:closeChatBox(\''+chatboxroomid+'\')">X</a></div><br clear="all"/></div><div class="chatboxcontent"></div><div class="chatboxinput"><textarea class="chatboxtextarea" onkeydown="javascript:return checkChatBoxInputKey(event,this,\''+chatboxroomid+'\');"></textarea></div>')
	.appendTo($( "body" ));
			   
	$("#chatbox_"+chatboxroomid).css('bottom', '0px');
	
	chatBoxeslength = 0;

	for (x in chatBoxes) {
		if ($("#chatbox_"+chatBoxes[x]).css('display') != 'none') {
			chatBoxeslength++;
		}
	}

	if (chatBoxeslength == 0) {
		$("#chatbox_"+chatboxroomid).css('right', '20px');
	} else {
		width = (chatBoxeslength)*(225+7)+20;
		$("#chatbox_"+chatboxroomid).css('right', width+'px');
	}
	
	chatBoxes.push(chatboxroomid);

	if (minimizeChatBox == 1) {
		minimizedChatBoxes = new Array();

		if ($.cookie('chatbox_minimized')) {
			minimizedChatBoxes = $.cookie('chatbox_minimized').split(/\|/);
		}
		minimize = 0;
		for (j=0;j<minimizedChatBoxes.length;j++) {
			if (minimizedChatBoxes[j] == chatboxroomid) {
				minimize = 1;
			}
		}

		if (minimize == 1) {
			$('#chatbox_'+chatboxroomid+' .chatboxcontent').css('display','none');
			$('#chatbox_'+chatboxroomid+' .chatboxinput').css('display','none');
		}
	}

	chatboxFocus[chatboxroomid] = false;

	$("#chatbox_"+chatboxroomid+" .chatboxtextarea").blur(function(){
		chatboxFocus[chatboxroomid] = false;
		$("#chatbox_"+chatboxroomid+" .chatboxtextarea").removeClass('chatboxtextareaselected');
	}).focus(function(){
		chatboxFocus[chatboxroomid] = true;
		newMessages[chatboxroomid] = false;
		$('#chatbox_'+chatboxroomid+' .chatboxhead').removeClass('chatboxblink');
		$("#chatbox_"+chatboxroomid+" .chatboxtextarea").addClass('chatboxtextareaselected');
	});

	$("#chatbox_"+chatboxroomid).click(function() {
		if ($('#chatbox_'+chatboxroomid+' .chatboxcontent').css('display') != 'none') {
			$("#chatbox_"+chatboxroomid+" .chatboxtextarea").focus();
		}
	});

	$("#chatbox_"+chatboxroomid).show();
}


function chatHeartbeat(){

	var itemsfound = 0;
	
	if (windowFocus == false) {
 
		var blinkNumber = 0;
		var titleChanged = 0;
		for (x in newMessagesWin) {
			if (newMessagesWin[x] == true) {
				++blinkNumber;
				if (blinkNumber >= blinkOrder) {
					document.title = usersNicks[x]+' says...';
					titleChanged = 1;
					break;	
				}
			}
		}
		
		if (titleChanged == 0) {
			document.title = originalTitle;
			blinkOrder = 0;
		} else {
			++blinkOrder;
		}

	} else {
		for (x in newMessagesWin) {
			newMessagesWin[x] = false;
		}
	}

	for (x in newMessages) {
		if (newMessages[x] == true) {
			if (chatboxFocus[x] == false) {
				//FIXME: add toggle all or none policy, otherwise it looks funny
				$('#chatbox_'+x+' .chatboxhead').toggleClass('chatboxblink');
			}
		}
	}
	
	$.ajax({
	  url: "/Chat/Heartbeat",
	  cache: false,
	  dataType: "json",
	  success: function(data) {

        UpdateUsersOnline(data.usersOnline, data.usersCount);
        
		$.each(data.items, function(i,item){
			if (item)	{ // fix strange ie bug

				chatboxtitle = item.room.title;
                chatboxroomid = item.room.id;
                
				if ($("#chatbox_"+chatboxroomid).length <= 0) {
					createChatBox(chatboxtitle, chatboxroomid);
				}
				if ($("#chatbox_"+chatboxroomid).css('display') == 'none') {
					$("#chatbox_"+chatboxroomid).css('display','block');
					restructureChatBoxes();
				}
				
				if (item.type == 1) {
					item.from = username;
				}

				if (item.type == 2) {
					$("#chatbox_"+chatboxroomid+" .chatboxcontent").append('<div class="chatboxmessage"><span class="chatboxinfo">'+item.message+'</span></div>');
				} else {
					newMessages[chatboxroomid] = true;
					newMessagesWin[item.fromId] = true;
					$("#chatbox_"+chatboxroomid+" .chatboxcontent").append('<div class="chatboxmessage"><span class="chatboxmessagefrom">'+item.from+':&nbsp;&nbsp;</span><span class="chatboxmessagecontent">'+item.message+'</span></div>');
				}

				$("#chatbox_"+chatboxroomid+" .chatboxcontent").scrollTop($("#chatbox_"+chatboxroomid+" .chatboxcontent")[0].scrollHeight);
				itemsfound += 1;
			}
		});

		chatHeartbeatCount++;

		if (itemsfound > 0) {
			chatHeartbeatTime = minChatHeartbeat;
			chatHeartbeatCount = 1;
		} else if (chatHeartbeatCount >= 10) {
			chatHeartbeatTime *= 2;
			chatHeartbeatCount = 1;
			if (chatHeartbeatTime > maxChatHeartbeat) {
				chatHeartbeatTime = maxChatHeartbeat;
			}
		}
		
		setTimeout('chatHeartbeat();',chatHeartbeatTime);
	}});
}

function closeChatBox(chatboxroomid) {
	$('#chatbox_'+chatboxroomid).remove();
    for (var i = 0; i < chatBoxes.length; i++)
    { 
        if (chatBoxes[i] == chatboxroomid)
            chatBoxes.splice(i, 1); 
    } 
	restructureChatBoxes();

	$.post("/Chat/Close", { roomId: chatboxroomid} , function(data){	
	});

}

function toggleChatBoxGrowth(chatboxroomid) {
	if ($('#chatbox_'+chatboxroomid+' .chatboxcontent').css('display') == 'none') {  
		
		var minimizedChatBoxes = new Array();
		
		if ($.cookie('chatbox_minimized')) {
			minimizedChatBoxes = $.cookie('chatbox_minimized').split(/\|/);
		}

		var newCookie = '';

		for (i=0;i<minimizedChatBoxes.length;i++) {
			if (minimizedChatBoxes[i] != chatboxroomid) {
				newCookie += chatboxroomid+'|';
			}
		}

		newCookie = newCookie.slice(0, -1)


		$.cookie('chatbox_minimized', newCookie);
		$('#chatbox_'+chatboxroomid+' .chatboxcontent').css('display','block');
		$('#chatbox_'+chatboxroomid+' .chatboxinput').css('display','block');
		$("#chatbox_"+chatboxroomid+" .chatboxcontent").scrollTop($("#chatbox_"+chatboxroomid+" .chatboxcontent")[0].scrollHeight);
	} else {
		
		var newCookie = chatboxroomid;

		if ($.cookie('chatbox_minimized')) {
			newCookie += '|'+$.cookie('chatbox_minimized');
		}


		$.cookie('chatbox_minimized',newCookie);
		$('#chatbox_'+chatboxroomid+' .chatboxcontent').css('display','none');
		$('#chatbox_'+chatboxroomid+' .chatboxinput').css('display','none');
	}
	
}

function toggleUsersOnline() {
	if ($('#UsersOnline .UsersOnlineContent').css('display') == 'none') {
		$.cookie('users_online_minimized', '0');
		$('#UsersOnline .UsersOnlineContent').css('display','block');
		$("#UsersOnline .UsersOnlineContent").scrollTop($("#UsersOnline .UsersOnlineContent")[0].scrollHeight);
	} else {
		$.cookie('users_online_minimized', '1');
		$('#UsersOnline .UsersOnlineContent').css('display','none');
	}
	
}

function checkChatBoxInputKey(event,chatboxtextarea,chatboxroomid) {
	 
	if(event.keyCode == 13 && event.shiftKey == 0)  {
		message = $(chatboxtextarea).val();
		message = message.replace(/^\s+|\s+$/g,"");

		$(chatboxtextarea).val('');
		$(chatboxtextarea).focus();
		$(chatboxtextarea).css('height','44px');
		if (message != '') {
			$.post("/Chat/Send", {roomId: chatboxroomid, message: message} , function(data){
				message = message.replace(/</g,"&lt;").replace(/>/g,"&gt;").replace(/\"/g,"&quot;");
				$("#chatbox_"+chatboxroomid+" .chatboxcontent").append('<div class="chatboxmessage"><span class="chatboxmessagefrom">'+username+':&nbsp;&nbsp;</span><span class="chatboxmessagecontent">'+message+'</span></div>');
				$("#chatbox_"+chatboxroomid+" .chatboxcontent").scrollTop($("#chatbox_"+chatboxroomid+" .chatboxcontent")[0].scrollHeight);
			});
		}
		chatHeartbeatTime = minChatHeartbeat;
		chatHeartbeatCount = 1;

		return false;
	}

	var adjustedHeight = chatboxtextarea.clientHeight;
	var maxHeight = 94;

	if (maxHeight > adjustedHeight) {
		adjustedHeight = Math.max(chatboxtextarea.scrollHeight, adjustedHeight);
		if (maxHeight)
			adjustedHeight = Math.min(maxHeight, adjustedHeight);
		if (adjustedHeight > chatboxtextarea.clientHeight)
			$(chatboxtextarea).css('height',adjustedHeight+8 +'px');
	} else {
		$(chatboxtextarea).css('overflow','auto');
	}
	 
}

function startChatSession(){  
	$.ajax({
	  url: "/Chat/StartSession",
	  cache: false,
	  dataType: "json",
	  success: function(data) {
 
		username = data.username;
        
        UpdateUsersOnline(data.usersOnline, data.usersCount);
        
		$.each(data.items, function(i,item){
			if (item)	{ // fix strange ie bug

				chatboxtitle = item.room.title;
                chatboxroomid = item.room.id;

				if ($("#chatbox_"+chatboxroomid).length <= 0) {
					createChatBox(chatboxtitle, chatboxroomid, 1);
				}
				
				if (item.type == 1) {
					item.from = username;
				}

				if (item.type == 2) {
					$("#chatbox_"+chatboxroomid+" .chatboxcontent").append('<div class="chatboxmessage"><span class="chatboxinfo">'+item.message+'</span></div>');
				} else {
					$("#chatbox_"+chatboxroomid+" .chatboxcontent").append('<div class="chatboxmessage"><span class="chatboxmessagefrom">'+item.from+':&nbsp;&nbsp;</span><span class="chatboxmessagecontent">'+item.message+'</span></div>');
				}
			}
		});
		
		for (i=0;i<chatBoxes.length;i++) {
			chatboxroomid = chatBoxes[i];
			$("#chatbox_"+chatboxroomid+" .chatboxcontent").scrollTop($("#chatbox_"+chatboxroomid+" .chatboxcontent")[0].scrollHeight);
			setTimeout('$("#chatbox_"+chatboxroomid+" .chatboxcontent").scrollTop($("#chatbox_"+chatboxroomid+" .chatboxcontent")[0].scrollHeight);', 100); // yet another strange ie bug
		}
	
	setTimeout('chatHeartbeat();',chatHeartbeatTime);
		
	}});
}
