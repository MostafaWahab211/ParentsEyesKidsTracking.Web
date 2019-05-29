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
    public class ParentController : ApiController
    {
        private ApplicationUserManager _userManager;
        KidsTrackingContext context = new KidsTrackingContext();
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public async Task<IHttpActionResult> RegisterAsync(Parent parent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new Parent() { UserName = parent.Email, Email = parent.Email, Location =parent.Location, Kids = parent.Kids };

            IdentityResult result = await UserManager.CreateAsync(user, parent.PasswordHash);
            

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }
        public IHttpActionResult Update(Parent parent)
        {
            if (ModelState.IsValid)
            {
                Parent oldParent = context.Parents.FirstOrDefault(p => p.Id == parent.Id);

                if (oldParent != null)
                {
                    oldParent.Email = parent.Email;
                    oldParent.PhoneNumber = parent.PhoneNumber;
                    oldParent.Kids = parent.Kids;
                    context.Entry<Parent>(oldParent).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return Ok(oldParent);
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
                Parent parent = context.Parents.FirstOrDefault(p => p.Id == id);
                if (id != null)
                {
                    context.Parents.Remove(parent);
                    context.SaveChanges();
                    return Ok();
                }
                else
                    return NotFound();
            }
            else
                return BadRequest();
        }
        public IHttpActionResult UpdateLocation(ParentLocationModelView parentLocationModelView)
        {
            if (ModelState.IsValid)
            {
                Parent parent = context.Parents.FirstOrDefault(p => p.Id == parentLocationModelView.ParentId);
                parent.Location = parentLocationModelView.Location;
                context.Entry<Parent>(parent).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return Ok();

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

        
