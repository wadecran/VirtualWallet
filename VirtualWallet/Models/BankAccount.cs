﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Web;
using VirtualWallet.Enums;
using VirtualWallet.Extentions;

namespace VirtualWallet.Models
{
    public class BankAccount
    {
        public int Id { get; set; }

        public int? HouseholdId { get; set; }

        public string OwnerId { get; set; }

        public virtual Household Household { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        [Display(Name = "Bank Account Name")]
        public string AccountName { get; set; }

        public DateTime Created { get; set; }

        [Display(Name = "Starting Balance")]
        public decimal StartingBalance { get; internal set; }

        [Display(Name = "Current Balance")]
        public decimal CurrentBalance { get; set; }

        [Display(Name = "Warning Balance")]
        public decimal WarningBalance { get; set; }

        [Display(Name = "Delete Account")]
        public bool IsDeleted { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

        [Display(Name = "Account type")]
        public AccountType AccountType { get; set; }

        public BankAccount(decimal startingBalance, decimal warningBalance, string accountName)
        {
            Transactions = new HashSet<Transaction>();
            StartingBalance = startingBalance;
            CurrentBalance = StartingBalance;
            WarningBalance = warningBalance;
            Created = DateTime.Now;
            AccountName = accountName;
            OwnerId = HttpContext.Current.User.Identity.GetUserId();
            HouseholdId = (int)HttpContext.Current.User.Identity.GetHouseholdId();
        }

        public BankAccount()
        {
            StartingBalance = -1;
        }
    }
}