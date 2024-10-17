using AutoMapper;
using Book.API.Infrastructure.Extensions;
using Book.API.Models;
using Book.Core.Interfaces;
using Book.Core.Models;
using Book.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Book.API.Controllers;
public class AccountController(IAccountService accountService,IUnitOfWork unitOfWork, IMapper mapper) : BaseApiController
{
    [HttpPost("register")]
    public async Task<ActionResult<AppUser>> Register(AppUserViewModel appUserView)
    {
        var userModel = mapper.Map<AppUser>(appUserView);

        userModel.UpdateAppUser(appUserView);
        accountService.Create(userModel);
        if (await unitOfWork.Complete())
        {
            return Ok(userModel);
        }
        else
        {
            return BadRequest("Create unsuccessfully");
        }
    }

    [HttpPut("update-profile")]
    public async Task<ActionResult> UpdateProfile(AppUserViewModel appUserView)
    {
      var accountExist  =  await accountService.GetByIdAsync(appUserView.Id);
        if (accountExist == null) return BadRequest();
        var userModel = mapper.Map<AppUser>(appUserView);

        userModel.UpdateAppUser(appUserView);
        accountService.Update(userModel);
        if (await unitOfWork.Complete())
        {
            return Ok(accountExist);
        }
        else
        {
            return BadRequest("Create unsuccessfully");
        }
    }
    [HttpGet("ListAccount")]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetAll()
    {
        var list = await accountService.GetAllAsync();
        return Ok(list);  
    }
}
