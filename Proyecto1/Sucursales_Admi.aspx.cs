﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1
{
    public partial class Surcusales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admi.aspx");//se redirecciona al Login
        }
    }
}