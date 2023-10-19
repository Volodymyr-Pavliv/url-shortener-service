using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace url_shortener_service.Areas.Identity.Data;


public class Url 
{
    public int Id { get; set; }

    public string OriginValue { get; set; }

    public string ShortValue { get; set; }
}

