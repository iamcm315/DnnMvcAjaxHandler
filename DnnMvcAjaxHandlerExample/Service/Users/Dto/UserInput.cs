﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DnnMvcAjaxHandlerExample.Service.Users.Dto
{
    public class UserInput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public DateTime AddDate { get; set; }

    }
}