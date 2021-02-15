using Messenger.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Messenger.Data
{
    public static class DbSetExtansions
    {
        public static IQueryable<Employee> GetEmployeesWithPageOptions(this DbSet<Employee> employees, PageOptions pageOptions)
        {
            //var query = employees;

            //foreach (var filter in pageOptions.Filter)
            //{
            //    System.Reflection.PropertyInfo prop = typeof(Employee).GetProperty(pageOptions.SortOrder.Field);
            //    query = query.Where(e=> prop.GetValue(e, null));
            //}

            var query = employees
                .Include(e => e.FullName)
                .Include(e => e.WorkingPlace)
                .Skip(pageOptions.PageSize * (pageOptions.PageNumber- 1))
                .Take(pageOptions.PageSize);
                //.TakeLast(pageOptions.PageSize);

            //if(pageOptions.SortOrder.Order == Order.Asc)
            //{
            //    System.Reflection.PropertyInfo prop = typeof(Employee).GetProperty(pageOptions.SortOrder.Field);
            //    query.OrderBy(e => prop.GetValue(e, null));
            //}
            //else
            //{
            //    System.Reflection.PropertyInfo prop = typeof(Employee).GetProperty(pageOptions.SortOrder.Field);
            //    query.OrderByDescending(e => prop.GetValue(e, null));
            //}
            
            return query;
        }

        public static IQueryable<Message> GetMessagesWithPageOptions(this DbSet<Message> employees, PageOptions pageOptions)
        {
            //var query = employees;

            //foreach (var filter in pageOptions.Filter)
            //{
            //    System.Reflection.PropertyInfo prop = typeof(Employee).GetProperty(pageOptions.SortOrder.Field);
            //    query = query.Where(e=> prop.GetValue(e, null));
            //}

            var query = employees
                .Include(e => e.Employee)
                .Skip(pageOptions.PageSize * (pageOptions.PageNumber - 1))
                .Take(pageOptions.PageSize);
            //.TakeLast(pageOptions.PageSize);

            //if(pageOptions.SortOrder.Order == Order.Asc)
            //{
            //    System.Reflection.PropertyInfo prop = typeof(Employee).GetProperty(pageOptions.SortOrder.Field);
            //    query.OrderBy(e => prop.GetValue(e, null));
            //}
            //else
            //{
            //    System.Reflection.PropertyInfo prop = typeof(Employee).GetProperty(pageOptions.SortOrder.Field);
            //    query.OrderByDescending(e => prop.GetValue(e, null));
            //}

            return query;
        }
    }
}
