/* Title:           Employee Time Clock Entries Class
 * Date:            10-19-18
 * Author:          Terry Holmes
 * 
 * Description:     This is the class for time clock entries */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace EmployeeTimeClockEntriesDLL
{
    public class EmployeeTimeClockEntriesClass
    {
        EventLogClass TheEventLogClass = new EventLogClass();

        EmployeeTimeClockEntriesDataSet aEmployeetimeClockEntriesDataSet;
        EmployeeTimeClockEntriesDataSetTableAdapters.employeetimeclockentriesTableAdapter aEmployeeTimeClockEntriesTableAdapter;

        InsertEmployeeTimeClockPunchEntryTableAdapters.QueriesTableAdapter aInsertEmployeeTimeClockPunchTableAdapter;

        UpdateEmployeeTimeClockPunchEntryTableAdapters.QueriesTableAdapter aUpdateEmployeeTimeClockEntryTableAdapter;

        FindEmployeeTimeCardEntriesDataSet aFindEmployeeTimeCardEntriesDataSet;
        FindEmployeeTimeCardEntriesDataSetTableAdapters.FindEmployeeTimeCardEntriesTableAdapter aFindEmployeeTimeCardEntriesTableAdapter;

        FindEmployeeTimeCardEntriesForManagerDataSet aFindEmployeeTimeCardEntriesForManagerDataSet;
        FindEmployeeTimeCardEntriesForManagerDataSetTableAdapters.FindEmployeeTimeCardEntriesForAManagerTableAdapter aFindEmployeeTimeCardEntriesForManagerTableAdapter;

        public FindEmployeeTimeCardEntriesForManagerDataSet FindEmployeeTimeCardEntriesForManager(int intManagerID, DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindEmployeeTimeCardEntriesForManagerDataSet = new FindEmployeeTimeCardEntriesForManagerDataSet();
                aFindEmployeeTimeCardEntriesForManagerTableAdapter = new FindEmployeeTimeCardEntriesForManagerDataSetTableAdapters.FindEmployeeTimeCardEntriesForAManagerTableAdapter();
                aFindEmployeeTimeCardEntriesForManagerTableAdapter.Fill(aFindEmployeeTimeCardEntriesForManagerDataSet.FindEmployeeTimeCardEntriesForAManager, intManagerID, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Employee Time Clock Entries Class // Find Employee Time Card Entries for a Manager " + Ex.Message);
            }

            return aFindEmployeeTimeCardEntriesForManagerDataSet;
        }
        public FindEmployeeTimeCardEntriesDataSet FindEmployeeTimeCardEntries(int intEmployeeID, DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindEmployeeTimeCardEntriesDataSet = new FindEmployeeTimeCardEntriesDataSet();
                aFindEmployeeTimeCardEntriesTableAdapter = new FindEmployeeTimeCardEntriesDataSetTableAdapters.FindEmployeeTimeCardEntriesTableAdapter();
                aFindEmployeeTimeCardEntriesTableAdapter.Fill(aFindEmployeeTimeCardEntriesDataSet.FindEmployeeTimeCardEntries, intEmployeeID, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Employee Time Clock Entries Class // Find Employee Time Card Entries " + Ex.Message);
            }

            return aFindEmployeeTimeCardEntriesDataSet;
        }
        public bool UpdateEmployeeTimeClockEntry(int intTransactionID, DateTime datPunchTime, string strPunchStatus)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateEmployeeTimeClockEntryTableAdapter = new UpdateEmployeeTimeClockPunchEntryTableAdapters.QueriesTableAdapter();
                aUpdateEmployeeTimeClockEntryTableAdapter.UpdateEmployeeTimeClockPunch(intTransactionID, datPunchTime, strPunchStatus);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Employee Time Clock Entries Class // Update Employee Time Clock Entry " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public bool InsertEmployeeTimeClockEntry(int intEmployeeID, int intPayID, DateTime datPunchTime, string strPunchStatus)
        {
            bool blnFatalError = false;

            try
            {
                aInsertEmployeeTimeClockPunchTableAdapter = new InsertEmployeeTimeClockPunchEntryTableAdapters.QueriesTableAdapter();
                aInsertEmployeeTimeClockPunchTableAdapter.InsertEmployeeTimeClockEntry(intEmployeeID, intPayID, datPunchTime, strPunchStatus);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Employee Time Clock Entries Class // Insert Employee Time Clock Entry " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public EmployeeTimeClockEntriesDataSet GetEmployeeTimeClockEntriesInfo()
        {
            try
            {
                aEmployeetimeClockEntriesDataSet = new EmployeeTimeClockEntriesDataSet();
                aEmployeeTimeClockEntriesTableAdapter = new EmployeeTimeClockEntriesDataSetTableAdapters.employeetimeclockentriesTableAdapter();
                aEmployeeTimeClockEntriesTableAdapter.Fill(aEmployeetimeClockEntriesDataSet.employeetimeclockentries);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Employee Time Clock Entries // Get Employee Time Clock Entries Info " + Ex.Message);
            }

            return aEmployeetimeClockEntriesDataSet;
        }
        public void UpdateEmployeeTimeClockEntries(EmployeeTimeClockEntriesDataSet aEmployeetimeClockEntriesDataSet)
        {
            try
            {
                aEmployeeTimeClockEntriesTableAdapter = new EmployeeTimeClockEntriesDataSetTableAdapters.employeetimeclockentriesTableAdapter();
                aEmployeeTimeClockEntriesTableAdapter.Update(aEmployeetimeClockEntriesDataSet.employeetimeclockentries);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Employee Time Clock Entries // Update Employee Time Clock Entries DB " + Ex.Message);
            }
        }
    }
}
