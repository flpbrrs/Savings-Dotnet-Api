using Savings.Application.UseCases.Expenses.Register;
using Savings.Comunication.Enums;
using Savings.Comunication.Requests;
using Savings.Exceptions;

namespace ValidatorTests.Expenses.Register;

public class RegisterExpenseValidatorTest
{
    private readonly RegisterExpenseValidador validator = new();

    [Fact]
    public void Should_BeValid_When_RequestIsCorrect()
    {
        #region Arrange
        var request = CreateValidRequest();
        #endregion

        #region Act
        var requestValidation = validator.Validate(request);
        #endregion

        #region Assert
        Assert.True(requestValidation.IsValid);
        #endregion
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Should_HaveError_When_TitleIsNullOrEmpty(string? title)
    {
        #region Arrange
        var request = CreateValidRequest();
        request.Title = title!;
        #endregion

        #region Act
        var validation = validator.Validate(request);
        #endregion

        #region Assert
        Assert.False(validation.IsValid);
        Assert.NotEmpty(validation.Errors);

        Assert.Equal(
            validation.Errors.First().ErrorMessage,
            ResourceErrorCodes.TITLE_REQUIRED
        );
        #endregion
    }

    [Fact]
    public void Should_HaveError_When_TitleIsTooShort()
    {
        #region Arrange
        var request = CreateValidRequest();
        request.Title = "Shrt";
        #endregion

        #region Act
        var validation = validator.Validate(request);
        #endregion

        #region Assert
        Assert.Equal(
            validation.Errors.First().ErrorMessage,
            ResourceErrorCodes.TITLE_MIN_LENGHT.Replace("{MinLength}", "5")
        );
        #endregion
    }

    [Fact]
    public void Should_HaveError_When_DateIsInTheFuture()
    {
        #region Arrange
        var request = CreateValidRequest();
        request.Date = DateTime.Now.AddMonths(1);
        #endregion

        #region Act
        var validation = validator.Validate(request);
        #endregion

        #region Assert
        Assert.Equal(validation.Errors.First().ErrorMessage, ResourceErrorCodes.DATE_IN_FUTURE);
        #endregion
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Should_HaveError_When_AmountIsZeroOrNegative(decimal amount)
    {
        #region Arrange
        var request = CreateValidRequest();
        request.Amount = amount;
        #endregion

        #region Act
        var validation = validator.Validate(request);
        #endregion

        #region Assert
        Assert.Equal(
            validation.Errors.First().ErrorMessage,
            ResourceErrorCodes.AMOUNT_ZERO_OR_NEGATIVE
        );
        #endregion
    }

    [Fact]
    public void Should_HaveError_When_ExpenseTypeIsInvalid()
    {
        #region Arrange
        var request = CreateValidRequest();
        request.ExpenseType = (ExpenseType) 12;
        #endregion

        #region Act
        var validation = validator.Validate(request);
        #endregion

        #region Assert
        Assert.Equal(
            validation.Errors.First().ErrorMessage,
            ResourceErrorCodes.EXPENSE_TYPE_INVALID
        );
        #endregion
    }

    #region Support Methods
    private static RegisterExpenseRequestJson CreateValidRequest()
    {
        return new RegisterExpenseRequestJson
        {
            Title = "Valid Expense Title",
            Description = "Valid Expense Description",
            Amount = 12.5M,
            Date = DateTime.UtcNow.AddDays(-2),
            ExpenseType = Savings.Comunication.Enums.ExpenseType.Credit
        };
    }
    #endregion
}