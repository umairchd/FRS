﻿using FRS.Models.IdentityModels;

namespace FRS.Models.MenuModels
{
    /// <summary>
    /// MenuRights class for menu assoication with role
    /// </summary>
    public class MenuRight
    {
        #region Persistance Properties
        /// <summary>
        /// Menu Right Id
        /// </summary>
        public int MenuRightId { get; set; }

        /// <summary>
        /// Menu Id
        /// </summary>
        public int Menu_MenuId { get; set; }

        /// <summary>
        /// Role Id
        /// </summary>
        public string Role_Id { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Menu
        /// </summary>
        public virtual Menu Menu { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        public virtual UserRole AspNetRole { get; set; }

        #endregion
    }
}