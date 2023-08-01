﻿using System.Collections.Generic;
using FRS.Models.MenuModels;

namespace FRS.Web.ViewModels.Common
{
    /// <summary>
    /// Menu View Model
    /// </summary>
    public class MenuViewModel
    {
        /// <summary>
        /// Menu Rights
        /// </summary>
        public IEnumerable<MenuRight> MenuRights { get; set; }
        /// <summary>
        /// Menu Headers
        /// </summary>
        public IEnumerable<MenuRight> MenuHeaders { get; set; }
    }
}