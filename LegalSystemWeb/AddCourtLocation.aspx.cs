﻿using LegalSystemCore.Common;
using LegalSystemCore.Controller;
using LegalSystemCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LegalSystemWeb
{
    public partial class AddCourt : System.Web.UI.Page
    {
        List<CourtLocation> courtlocation = new List<CourtLocation>();
        List<Court> courtList = new List<Court>();
        List<Location> locationList = new List<Location>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Session["User_Role_Id"].ToString() == "1" || Session["User_Role_Id"].ToString() == "2")
                {
                    if (!IsPostBack)
                    {
                        BindCourtList();
                        BindLocationList();
                    }
                    BindDataSource();
                }
                else
                {
                    Response.Redirect("404.aspx");
                }

            }
        }

        private void BindDataSource()
        {
            ICourtLocationController courtlocationController = ControllerFactory.CreateCourtLocationController();

            courtlocation = courtlocationController.GetCourtLocationList();
            GridView2.DataSource = courtlocationController.GetCourtLocationList();
            GridView2.DataBind();
        }

        private void BindCourtList()
        {

            ICourtController courtController = ControllerFactory.CreateCourtController();

            courtList = courtController.GetCourtList();
            ddlCourt.DataSource = courtController.GetCourtList();
            ddlCourt.DataValueField = "CourtId";
            ddlCourt.DataTextField = "CourtName";
            ddlCourt.DataBind();

        }

        private void BindLocationList()
        {

            ILocationController locationController = ControllerFactory.CreateLocationController();

            locationList = locationController.GetLocationList();
            ddlLocation.DataSource = locationController.GetLocationList();
            ddlLocation.DataValueField = "LocationId";
            ddlLocation.DataTextField = "locationName";
            ddlLocation.DataBind();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            ICourtLocationController courtLocationController = ControllerFactory.CreateCourtLocationController();

            if (btnSave.Text == "Update")
            {
                int courtId = (int)ViewState["updatedRowIndex1"];
                int locationId = (int)ViewState["updatedRowIndex2"];
                CourtLocation courtlocation = new CourtLocation();
                courtlocation.CourtId = Convert.ToInt32(ddlCourt.SelectedValue);
                courtlocation.LocationId = Convert.ToInt32(ddlLocation.SelectedValue);

                courtLocationController.Update(courtlocation, courtId, locationId);
                btnSave.Text = "Save";
            }
            else
            {
                CourtLocation courtlocation = new CourtLocation();
                courtlocation.CourtId = Convert.ToInt32(ddlCourt.SelectedValue);
                courtlocation.LocationId = Convert.ToInt32(ddlLocation.SelectedValue);

                courtlocation.CourtId = courtLocationController.Save(courtlocation);
            }

            BindDataSource();

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            ICourtLocationController courLocationtController = ControllerFactory.CreateCourtLocationController();

            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            if (GridView2.PageIndex != 0)
            {
                rowIndex = (GridView2.PageSize + rowIndex) * (GridView2.PageIndex);
            }
            ddlCourt.SelectedValue = Convert.ToString(courtlocation[rowIndex].CourtId);
            ddlLocation.SelectedValue = Convert.ToString(courtlocation[rowIndex].LocationId);
            btnSave.Text = "Update";
            ViewState["updatedRowIndex1"] = courtlocation[rowIndex].CourtId;
            ViewState["updatedRowIndex2"] = courtlocation[rowIndex].LocationId;
        }

        protected void GridView2_OnPageIndexChanged(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            this.BindDataSource();
        }
    }
}