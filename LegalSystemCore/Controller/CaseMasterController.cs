﻿using LegalSystemCore.Common;
using LegalSystemCore.Domain;
using LegalSystemCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalSystemCore.Controller
{
    public interface ICaseMasterController
    {
        int Save(CaseMaster caseMaster);
        int Update(CaseMaster caseMaster);
        int CaseClose(CaseMaster caseMaster);
        int Delete(CaseMaster caseMaster);
        List<CaseMaster> GetCaseMasterList(bool withoutclosed);
        CaseMaster GetCaseMaster(string caseNumber);

        CaseMaster GetCaseMasterWithPaid(String caseNumber);
        int UpdateCasePaidAmount(CaseMaster caseMaster);

    }

    public class CaseMasterControllerImpl : ICaseMasterController
    {

        ICaseMasterDAO caseMasterDAO = DAOFactory.CreateCaseMasterDAO();

        public CaseMaster GetCaseMaster(string caseNumber)
        {
            DbConnection dbConnection = null;
            CaseMaster caseMaster = new CaseMaster();
            try
            {
                dbConnection = new DbConnection();
                caseMaster = caseMasterDAO.GetCaseMaster(caseNumber, dbConnection);
            }
            catch (Exception)
            {
                dbConnection.RollBack();
                throw;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                {
                    dbConnection.Commit();
                }
            }
            return caseMaster;
        }

        public List<CaseMaster> GetCaseMasterList(bool withoutclosed)
        {
            DbConnection dbConnection = null;
            List<CaseMaster> listCaseMaster = new List<CaseMaster>();
            try
            {
                dbConnection = new DbConnection();
                listCaseMaster = caseMasterDAO.GetCaseMasterList(withoutclosed, dbConnection);

                ICompanyDAO companyDAO = DAOFactory.CreateCompanyDAO();
                List<Company> listCompany = companyDAO.GetCompanyList(dbConnection);

                foreach (var caseMaster in listCaseMaster)
                {
                    caseMaster.company = listCompany.Where(x => x.CompanyId == caseMaster.CompanyId).Single();
                }

                ICompanyUnitDAO companyUnitDAO = DAOFactory.CreateCompanyUnitDAO();
                List<CompanyUnit> listCompanyUnit = companyUnitDAO.GetCompanyUnitList(dbConnection);

                foreach (var caseMaster in listCaseMaster)
                {
                    caseMaster.companyUnit = listCompanyUnit.Where(x => x.CompanyUnitId == caseMaster.CompanyUnitId).Single();
                }

                ICaseNatureDAO caseNatureDAO = DAOFactory.CreateCaseNatureDAO();
                List<CaseNature> listCaseNature = caseNatureDAO.GetCaseNatureList(dbConnection);

                foreach (var caseMaster in listCaseMaster)
                {
                    caseMaster.caseNature = listCaseNature.Where(x => x.CaseNatureId == caseMaster.CaseNatureId).Single();
                }

                ILocationDAO locationDAO = DAOFactory.CreateLocationDAO();
                List<Location> listLocation = locationDAO.GetLocationList(dbConnection);

                foreach (var caseMaster in listCaseMaster)
                {
                    caseMaster.location = listLocation.Where(x => x.LocationId == caseMaster.LocationId).Single();
                }
            }
            catch (Exception)
            {
                dbConnection.RollBack();
                throw;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                {
                    dbConnection.Commit();
                }
            }
            return listCaseMaster;
        }

        public int Save(CaseMaster caseMaster)
        {
            DbConnection dbConnection = null;
            try
            {
                dbConnection = new DbConnection();
                return caseMasterDAO.Save(caseMaster, dbConnection);
            }
            catch (Exception)
            {
                dbConnection.RollBack();
                throw;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                {
                    dbConnection.Commit();
                }
            }
        }

        public int Update(CaseMaster caseMaster)
        {
            DbConnection dbConnection = null;
            try
            {
                dbConnection = new DbConnection();
                return caseMasterDAO.Update(caseMaster, dbConnection);
            }
            catch (Exception)
            {
                dbConnection.RollBack();
                throw;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                {
                    dbConnection.Commit();
                }
            }
        }

        public int CaseClose(CaseMaster caseMaster)
        {
            DbConnection dbConnection = null;
            try
            {
                dbConnection = new DbConnection();
                return caseMasterDAO.CaseClose(caseMaster, dbConnection);
            }
            catch (Exception)
            {
                dbConnection.RollBack();
                throw;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                {
                    dbConnection.Commit();
                }
            }
        }
        public int Delete(CaseMaster caseMaster)
        {
            DbConnection dbConnection = null;
            try
            {
                dbConnection = new DbConnection();
                return caseMasterDAO.Delete(caseMaster, dbConnection);
            }
            catch (Exception)
            {
                dbConnection.RollBack();
                throw;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                {
                    dbConnection.Commit();
                }
            }
        }

        public CaseMaster GetCaseMasterWithPaid(String caseNumber)
        {
            DbConnection dbConnection = null;
            CaseMaster caseMaster = new CaseMaster();
            try
            {
                dbConnection = new DbConnection();
                caseMaster = caseMasterDAO.GetCaseMaster(caseNumber, dbConnection);
                caseMaster.totalPaidAmoutToPresent = caseMasterDAO.GetCaseMasterWithTotalPaidAmount(caseNumber, dbConnection);
            }
            catch (Exception)
            {
                dbConnection.RollBack();
                throw;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                {
                    dbConnection.Commit();
                }
            }
            return caseMaster;
        }

        public int UpdateCasePaidAmount(CaseMaster caseMaster)
        {
            DbConnection dbConnection = null;
            try
            {
                dbConnection = new DbConnection();
                return caseMasterDAO.UpdateCasePaidAmount(caseMaster, dbConnection);
            }
            catch (Exception)
            {
                dbConnection.RollBack();
                throw;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                {
                    dbConnection.Commit();
                }
            }
        }

    }
}
