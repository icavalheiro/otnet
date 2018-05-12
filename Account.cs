using OTNet.Enums;
using System.Collections.Generic;
using System;
using OTNet.DatabaseModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OTNet
{
    public class Account{
        public List<string> Characters;
        public string Name;
        public string Key;
        public DateTime LastDay;
        public UInt32 Id;
        public UInt16 PremiumDays;
        public UInt32 CoinBalance;
        public AccountType AccountType;
	};

	//TODO: try to merge this into the account class
	public static class IOAccount {

		#region precompiled query
		private static Func<OTNetContext, UInt32, UInt32> _queryCoinBalance = EF.CompileQuery((OTNetContext db, UInt32 accId) => (
			(from acc in db.Accounts
			 where acc.Id == accId
			 select acc.Coins)
			 .Single()
		));

		private static Func<OTNetContext, UInt32, Accounts> _queryAccount = EF.CompileQuery((OTNetContext db, UInt32 accId) => (
			(from acc in db.Accounts
			 where acc.Id == accId
			 select acc)
			 .Single()
		));
		#endregion

		public static UInt32 GetCoinBalance(UInt32 accountId){
			using(var db = new OTNetContext()){
				return _queryCoinBalance(db, accountId);
			}
		}

		public static void AddCoins(UInt32 accountId, Int32 amount){
			using(var db = new OTNetContext()){
				var account = _queryAccount(db, accountId);
				account.Coins += Convert.ToUInt32(amount);
				db.SaveChanges();
			}
		}

		public static void RemoveCoins(UInt32 accountId, Int32 amount){
			AddCoins(accountId, -amount);
		}

		public static void RegisterTransaction(UInt32 accountId, Int32 coins, string description){
			using(var db = new OTNetContext()){
				var newStoreHistory = new StoreHistory {
					AccountId = accountId,
					CoinAmount = coins,
					Description = description,
					Time = DateTime.Now
				};
				
				db.StoreHistory.Add(newStoreHistory);
				db.SaveChanges();
			}
		}
    }   
}