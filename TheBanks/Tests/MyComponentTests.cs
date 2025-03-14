using Bunit;
using Xunit;
using TheBanks.Components;

namespace TheBanks.Tests
{
    public class MyComponentTests : TestContext
    {
        [Fact]
        public void Deposit_ShouldUpdateBalance()
        {
            // Arrange
            var initialBalance = 1000;
            var depositAmount = 500;
            var expectedBalance = initialBalance + depositAmount;

            var component = RenderComponent<DepositForm>(parameters => parameters
                .Add(p => p.Balance, initialBalance));

            // Act
            component.Find("input[type='number']").Change(depositAmount);
            component.Find("button.deposit").Click();

            // Assert
            var displayedBalance = component.Find(".balance").InnerHtml; // Assurez-vous que le solde est affiché dans le composant
            Assert.Equal(expectedBalance.ToString(), displayedBalance);
        }

        [Fact]
        public void Withdrawal_ShouldUpdateBalance()
        {
            // Arrange
            var initialBalance = 1000;
            var withdrawalAmount = 300;
            var expectedBalance = initialBalance - withdrawalAmount;

            var component = RenderComponent<WithdrawForm>(parameters => parameters
                .Add(p => p.Balance, initialBalance)); // Utilisez WithdrawForm ici

            // Act
            component.Find("input[type='number']").Change(withdrawalAmount);
            component.Find("button.withdraw").Click();

            // Assert
            var displayedBalance = component.Find(".balance").InnerHtml; // Assurez-vous que le solde est affiché dans le composant
            Assert.Equal(expectedBalance.ToString(), displayedBalance);
        }

        [Fact]
        public void Withdrawal_ExceedsBalance_ShouldShowError()
        {
            // Arrange
            var initialBalance = 1000;
            var withdrawalAmount = 1500;

            var component = RenderComponent<WithdrawForm>(parameters => parameters
                .Add(p => p.Balance, initialBalance));

            // Act
            component.Find("input[type='number']").Change(withdrawalAmount);
            component.Find("button.withdraw").Click();

            // Assert
            var errorMessage = component.Find(".error-message").InnerHtml; // Assurez-vous que le message d'erreur est affiché
            Assert.Equal("Solde insuffisant.", errorMessage);
        }
    }
}