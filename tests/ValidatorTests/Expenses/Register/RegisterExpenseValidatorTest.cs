using CommonUtilitiesTest.Request;
using Savings.Application.UseCases.Expenses.Register;
using Savings.Comunication.Enums;
using Savings.Exceptions;
using Shouldly;

namespace ValidatorTests.Expenses.Register;

public class RegisterExpenseValidatorTest
{
    private readonly RegisterExpenseValidador validator = new();

    [Fact]
    public void Should_BeValid_When_RequestIsCorrect()
    {
        #region Arrange
        var request = RegisterExpenseRequestJsonBuilder.Build();
        #endregion

        #region Act
        var requestValidation = validator.Validate(request);
        #endregion

        #region Assert
        requestValidation.IsValid.ShouldBeTrue();
        #endregion
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Should_HaveError_When_TitleIsNullOrEmpty(string? title)
    {
        #region Arrange
        var request = RegisterExpenseRequestJsonBuilder.Build();
        request.Title = title!;
        #endregion

        #region Act
        var validation = validator.Validate(request);
        #endregion

        #region Assert
        validation.IsValid.ShouldBeFalse();
        validation.Errors.ShouldContain(e => e.ErrorMessage.Equals(ResourceErrorCodes.TITLE_REQUIRED));
        #endregion
    }

    [Fact]
    public void Should_HaveError_When_TitleIsTooShort()
    {
        #region Arrange
        var request = RegisterExpenseRequestJsonBuilder.Build();
        request.Title = "Shrt";
        #endregion

        #region Act
        var validation = validator.Validate(request);
        #endregion

        #region Assert
        validation.IsValid.ShouldBeFalse();
        validation.Errors.ShouldContain(e => e.ErrorMessage.Equals(ResourceErrorCodes.TITLE_MIN_LENGHT.Replace("{MinLength}", "5")));
        #endregion
    }

    [Fact]
    public void Should_HaveError_When_DateIsInTheFuture()
    {
        #region Arrange
        var request = RegisterExpenseRequestJsonBuilder.Build();
        request.Date = DateTime.Now.AddMonths(1);
        #endregion

        #region Act
        var validation = validator.Validate(request);
        #endregion

        #region Assert
        validation.IsValid.ShouldBeFalse();
        validation.Errors.ShouldContain(e => e.ErrorMessage.Equals(ResourceErrorCodes.DATE_IN_FUTURE));
        #endregion
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Should_HaveError_When_AmountIsZeroOrNegative(decimal amount)
    {
        #region Arrange
        var request = RegisterExpenseRequestJsonBuilder.Build();
        request.Amount = amount;
        #endregion

        #region Act
        var validation = validator.Validate(request);
        #endregion

        #region Assert
        validation.IsValid.ShouldBeFalse();
        validation.Errors.ShouldContain(e => e.ErrorMessage.Equals(ResourceErrorCodes.AMOUNT_ZERO_OR_NEGATIVE));
        #endregion
    }

    [Fact]
    public void Should_HaveError_When_ExpenseTypeIsInvalid()
    {
        #region Arrange
        var request = RegisterExpenseRequestJsonBuilder.Build();
        request.ExpenseType = (ExpenseType) 12;
        #endregion

        #region Act
        var validation = validator.Validate(request);
        #endregion

        #region Assert
        validation.IsValid.ShouldBeFalse();
        validation.Errors.ShouldContain(e => e.ErrorMessage.Equals(ResourceErrorCodes.EXPENSE_TYPE_INVALID));
        #endregion
    }
}