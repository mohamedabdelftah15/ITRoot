﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ITRoot_Task.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ITRoot_Task_DBEntities : DbContext
    {
        public ITRoot_Task_DBEntities()
            : base("name=ITRoot_Task_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
    
        public virtual int AddUser(string fullName, string userName, string password, string email, string phone, Nullable<int> roleID, string createdBy, Nullable<System.DateTime> createdDate)
        {
            var fullNameParameter = fullName != null ?
                new ObjectParameter("FullName", fullName) :
                new ObjectParameter("FullName", typeof(string));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var roleIDParameter = roleID.HasValue ?
                new ObjectParameter("RoleID", roleID) :
                new ObjectParameter("RoleID", typeof(int));
    
            var createdByParameter = createdBy != null ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(string));
    
            var createdDateParameter = createdDate.HasValue ?
                new ObjectParameter("CreatedDate", createdDate) :
                new ObjectParameter("CreatedDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddUser", fullNameParameter, userNameParameter, passwordParameter, emailParameter, phoneParameter, roleIDParameter, createdByParameter, createdDateParameter);
        }
    
        public virtual ObjectResult<CheckLogin_Result> CheckLogin(string userName, string password, Nullable<int> roleID)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var roleIDParameter = roleID.HasValue ?
                new ObjectParameter("RoleID", roleID) :
                new ObjectParameter("RoleID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CheckLogin_Result>("CheckLogin", userNameParameter, passwordParameter, roleIDParameter);
        }
    
        public virtual int DeleteUser(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteUser", iDParameter);
        }
    
        public virtual int EditUser(Nullable<int> iD, string fullName, string userName, string password, string email, Nullable<bool> confirmedEmail, string phone, Nullable<int> roleID, string updatedBy, Nullable<System.DateTime> updatedDate)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var fullNameParameter = fullName != null ?
                new ObjectParameter("FullName", fullName) :
                new ObjectParameter("FullName", typeof(string));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var confirmedEmailParameter = confirmedEmail.HasValue ?
                new ObjectParameter("ConfirmedEmail", confirmedEmail) :
                new ObjectParameter("ConfirmedEmail", typeof(bool));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var roleIDParameter = roleID.HasValue ?
                new ObjectParameter("RoleID", roleID) :
                new ObjectParameter("RoleID", typeof(int));
    
            var updatedByParameter = updatedBy != null ?
                new ObjectParameter("UpdatedBy", updatedBy) :
                new ObjectParameter("UpdatedBy", typeof(string));
    
            var updatedDateParameter = updatedDate.HasValue ?
                new ObjectParameter("UpdatedDate", updatedDate) :
                new ObjectParameter("UpdatedDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EditUser", iDParameter, fullNameParameter, userNameParameter, passwordParameter, emailParameter, confirmedEmailParameter, phoneParameter, roleIDParameter, updatedByParameter, updatedDateParameter);
        }
    
        public virtual ObjectResult<UserList_Result> UserList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UserList_Result>("UserList");
        }
    }
}
