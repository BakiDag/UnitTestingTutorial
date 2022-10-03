using Bank;
using System;
using Xunit;

namespace BankXUnitTests
{
    public class BankAccountTests
    {
        [Fact]
        public void Adding_Funds_Updates_Balance() {

			//Arrange
			BankAccount account = new BankAccount(1000);
						
			//Act
			account.Add(100);

            //Assert
            Assert.Equal(1100, account.Balance);
        }

        [Fact]
        public void Adding_Negative_Funds_Throws() {

            //Arrange
            BankAccount account = new BankAccount(1000);

            //Act +Assert            
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Add(-100));
        }

        [Fact]
        public void Withdrawing_Funds_Updates_Balance() {

            //Arrange
            BankAccount account = new BankAccount(1000);

            //Act
            account.Withdraw(100);

            //Assert
            Assert.Equal(900, account.Balance);
        }

        [Fact]
        public void Withdrawing_Negative_Funds_Throws() {

            //Arrange
            BankAccount account = new BankAccount(1000);

            //Act + Assert             
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(-100));
        }

        [Fact]
        public void Withdrawing_More_Than_Funds_Throws() {

            //Arrange
            BankAccount account = new BankAccount(1000);

            //Act + Assert             
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(2000));
        }

        [Fact]
        public void Transfering_Funds_Updates_Both_Accounts() {

            //Arrange
            BankAccount account = new BankAccount(1000);
            BankAccount otherAccount = new BankAccount();

            //Act
            account.TransferFundsTo(otherAccount, 500);

            //Assert
            Assert.Equal(500, account.Balance);
            Assert.Equal(500, otherAccount.Balance);
        }

        [Fact]
        public void TransferFundsTo_Non_Existing_Account_Throws() {

            //Arrange
            BankAccount account = new BankAccount(1000);

            //Act + Assert             
            Assert.Throws<ArgumentNullException>(() => account.TransferFundsTo(null, 2000));
        }
    }
}
