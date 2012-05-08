/*=======================================================================
  Copyright (C) Microsoft Corporation.  All rights reserved.
 
  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
  PARTICULAR PURPOSE.
=======================================================================*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using RssToolkit.Rss;
using RssToolkit.Web.Design;

namespace RssToolkit.Web.WebControls
{
    /// <summary>
    /// RSS data source control implementation, including the designer
    /// </summary>
    [Designer(typeof(RssDataSourceDesigner))]
    [DefaultProperty("Url")]
    public class RssDataSource : DataSourceControl
    {
        private int _maxItems;
        private string _url;
        private RssDataSourceView _itemsView;
        private RssDocument _rss;

        /// <summary>
        /// Initializes a new instance of the <see cref="RssDataSource"/> class.
        /// </summary>
        public RssDataSource() 
        {
        }

        /// <summary>
        /// Gets or sets the max items.
        /// </summary>
        /// <value>The max items.</value>
        public int MaxItems
        {
            get
            {
                return _maxItems;
            }

            set
            {
                _maxItems = value;
            }
        }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        public string Url
        {
            get
            {
                return _url;
            }

            set
            {
                _rss = null;
                _url = value;
            }
        }

        /// <summary>
        /// Gets the RSS.
        /// </summary>
        /// <value>The RSS.</value>
        public RssDocument Rss
        {
            get
            {
                if (_rss == null)
                {
                    _rss = RssDocument.Load(new System.Uri(_url));
                }

                return _rss;
            }
        }

        /// <summary>
        /// Gets the named data source view associated with the data source control.
        /// </summary>
        /// <param name="viewName">The name of the <see cref="T:System.Web.UI.DataSourceView"></see> to retrieve. In data source controls that support only one view, such as <see cref="T:System.Web.UI.WebControls.SqlDataSource"></see>, this parameter is ignored.</param>
        /// <returns>
        /// Returns the named <see cref="T:System.Web.UI.DataSourceView"></see> associated with the <see cref="T:System.Web.UI.DataSourceControl"></see>.
        /// </returns>
        protected override DataSourceView GetView(string viewName) 
        {
            if (_itemsView == null)
            {
                _itemsView = new RssDataSourceView(this, viewName);
            }

            return _itemsView;
        }
    }
}
