using SogyoLunchApp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Domain;

namespace SogyoLunchApp
{
    public class AppUser : IdentityUser<Guid>
    {

    }
}