using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ParentsEyesKidsTracking.Web.Models;
using ParentsEyesKidsTracking.Web.Models.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ParentsEyesKidsTracking.Web.Controllers
{
    public class KidController : ApiController
    {
        KidsTrackingContext context = new KidsTrackingContext();
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }

        public async Task<IHttpActionResult> RegisterAsync(Kid kid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new Kid() { UserName = kid.Email, Email = kid.Email, Location = kid.Location, Parent = kid.Parent };
           IdentityResult result = await UserManager.CreateAsync(user, kid.PasswordHash);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        public IHttpActionResult Update(Kid kid)
        {
            if (ModelState.IsValid)
            {
                Kid oldKid = context.Kids.FirstOrDefault(c => c.Id == kid.Id);
                if (oldKid != null)
                {
                    oldKid.Name = kid.Name;
                    oldKid.Age = kid.Age;
                    oldKid.PhoneNumber = kid.PhoneNumber;
                    oldKid.Location = kid.Location;
                    oldKid.UserName = kid.UserName;
                    context.Entry<Kid>(oldKid).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        public IHttpActionResult Remove(string id)
        {
            if (id != null)
            {
                Kid kid = context.Kids.FirstOrDefault(k => k.Id == id);
                {
                    if (kid != null)
                    {
                        context.Kids.Remove(kid);
                        context.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            return BadRequest();
        }

        public IHttpActionResult LocationUpdate(KidLocationModelView kidLocationModelView)
        {
            if (ModelState.IsValid)
            {
                Kid kid = context.Kids.FirstOrDefault(k => k.Id == kidLocationModelView.KidId);
                if (kid != null)
                {
                        kid.Location = kidLocationModelView.Location;
                        context.Entry<Kid>(kid).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                        return Ok();
                    
                }
                else
                    return NotFound();
            }
            else
                return BadRequest(ModelState);
        }
        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
