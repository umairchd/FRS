﻿using Cares.Models.DomainModels;
using Cares.Models.IdentityModels;
using Cares.Models.IdentityModels.ViewModels;
using Cares.Web.Controllers;
using FRS.Implementation.Identity;
using FRS.Interfaces.IServices;
using FRS.Models.IdentityModels;
using FRS.Models.MenuModels;
using FRS.Web.ViewModels.RightsManagement;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using MenuRightModel = FRS.Web.Models.MenuRight;
using Cares.Commons;
using System;

namespace Cares.Web.Controllers
{
    public class RolesAdminController : Controller
    {
        private IMenuRightsService menuRightsService;
        public RolesAdminController()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public RolesAdminController(IMenuRightsService menuRightsService)
        {
            this.menuRightsService = menuRightsService;
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }

        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        /// <summary>
        /// Get All Roles
        /// </summary>
        public ActionResult Index()
        {
            return View(RoleManager.Roles.Where(role => role.Name.ToLower() != "admin" && role.Name.ToLower() != "systemadministrator"));
        }

        /// <summary>
        /// Gets Roles Details
        /// </summary>
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByIdAsync(id);
            // Get the list of Users in this Role
            var users = new List<AspNetUser>();

            // Get the list of Users in this Role
            foreach (var user in UserManager.Users.ToList())
            {
                if (await UserManager.IsInRoleAsync(user.Id, role.Name))
                {
                    users.Add(user);
                }
            }

            ViewBag.Users = users;
            ViewBag.UserCount = users.Count();
            return View(role);
        }

       /// <summary>
       /// Flash
       /// </summary>
       /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Saves Newly created Role
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                var role = new UserRole { Name = roleViewModel.Name };
                var roleresult = await RoleManager.CreateAsync(role);
                if (!roleresult.Succeeded)
                {
                    ModelState.AddModelError("", roleresult.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }

       
        // GET: /Roles/Edit/Admin
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByIdAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            RoleViewModel roleModel = new RoleViewModel { Id = role.Id, Name = role.Name };
            return View(roleModel);
        }

        //
        // POST: /Roles/Edit/5
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Name,Id")] RoleViewModel roleModel)
        {
            if (ModelState.IsValid)
            {
                var role = await RoleManager.FindByIdAsync(roleModel.Id);
                role.Name = roleModel.Name;
                await RoleManager.UpdateAsync(role);
                return RedirectToAction("Index");
            }
            return View();
        }

        //
        // GET: /Roles/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByIdAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        //
        // POST: /Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id, string deleteUser)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var role = await RoleManager.FindByIdAsync(id);
                if (role == null)
                {
                    return HttpNotFound();
                }
                IdentityResult result;
                if (deleteUser != null)
                {
                    result = await RoleManager.DeleteAsync(role);
                }
                else
                {
                    result = await RoleManager.DeleteAsync(role);
                }
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult RightsManagement()
        {
            UserMenuResponse userMenuRights = menuRightsService.GetRoleMenuRights(string.Empty);
            RightsManagementViewModel viewModel = new RightsManagementViewModel();
            viewModel.Roles = userMenuRights.Roles.Where(role => role.Name != "SystemAdministrator").ToList();
            viewModel.Rights =
                userMenuRights.Menus.Select(
                    m =>
                        new MenuRightModel
                        {
                            MenuId = m.MenuId,
                            MenuTitle = m.MenuTitle,
                            IsParent = m.IsRootItem,
                            IsSelected = userMenuRights.MenuRights.Any(menu => menu.Menu.MenuId == m.MenuId),
                            //ParentId = m.ParentItem != null ? m.ParentItem.MenuId : (int?)null
                        }).ToList();
            return View(viewModel);
        }

        public ActionResult PostRightsManagement(string roleValue, string selectedList)
        {

            UserMenuResponse userMenuRights = menuRightsService.SaveRoleMenuRight(roleValue, selectedList, RoleManager.FindById(roleValue));
            RightsManagementViewModel viewModel = new RightsManagementViewModel();

            viewModel.Roles = userMenuRights.Roles.ToList();
            viewModel.Rights =
                userMenuRights.Menus.Select(
                    m =>
                        new MenuRightModel
                        {
                            MenuId = m.MenuId,
                            MenuTitle = m.MenuTitle,
                            IsParent = m.IsRootItem,
                            IsSelected = userMenuRights.MenuRights.Any(menu => menu.Menu.MenuId == m.MenuId),
                            //ParentId = m.ParentItem != null ? m.ParentItem.MenuId : (int?)null
                        }).ToList();
            viewModel.SelectedRoleId = roleValue;
            return View("RightsManagement", viewModel);

        }

        [HttpPost]
        public ActionResult RightsManagement(FormCollection collection)
        {
            string RoleId = collection.Get("SelectedRoleId");
            UserMenuResponse userMenuRights = menuRightsService.GetRoleMenuRights(RoleId);
            RightsManagementViewModel viewModel = new RightsManagementViewModel();

            viewModel.Roles = userMenuRights.Roles.ToList();
            viewModel.Rights =
                userMenuRights.Menus.Select(
                    m =>
                        new MenuRightModel
                        {
                            MenuId = m.MenuId,
                            MenuTitle = m.MenuTitle,
                            IsParent = m.IsRootItem,
                            IsSelected = userMenuRights.MenuRights.Any(menu => menu.Menu.MenuId == m.MenuId),
                            //ParentId = m.ParentItem != null ? m.ParentItem.MenuId : (int?)null,

                        }).ToList();
            viewModel.SelectedRoleId = RoleId;
            return View(viewModel);
        }

    }
}
