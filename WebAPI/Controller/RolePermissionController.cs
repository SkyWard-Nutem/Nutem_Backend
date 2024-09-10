﻿using Application.Helper;
using Application.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePermissionController : ControllerBase
    {
        private readonly IRolePermissionService _rolePermissionService;

        public RolePermissionController(IRolePermissionService rolePermissionService)
        {
            _rolePermissionService = rolePermissionService;
        }

        [HttpPost("AddRolePermission")]
        public async Task<IActionResult> AddRolePermission([FromBody] RolePermissionAddEdit model)
        {
            var response = await _rolePermissionService.AddRolePermissionAsync(model, User.Identity.GetUserId());
            return Ok(response);
        }

        [HttpPost("UpdateRolePermission")]
        public async Task<IActionResult> UpdateRolePermission([FromBody] RolePermissionAddEdit model)
        {
            var response = await _rolePermissionService.UpdateRolePermissionAsync(model, User.Identity.GetUserId());
            return Ok(response);
        }

        [HttpGet("GetAllRolePermissions")]
        public async Task<IActionResult> GetAllRolePermissions()
        {
            var data = await _rolePermissionService.GetAllRolePermissionsAsync();
            return Ok(data);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetRolePermissionById(int id)
        {
            var data = await _rolePermissionService.GetRolePermissionByIdAsync(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteRolePermission(int id)
        {
            long userId = User.Identity.GetUserId();
            await _rolePermissionService.DeleteRolePermissionAsync(id, userId);
            return NoContent();
        }
    }
}