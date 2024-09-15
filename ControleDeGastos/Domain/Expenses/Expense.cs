using Domain.Categories;
using Domain.Common;

namespace Domain.Expenses;
public class Expense : BaseClass
{
    public Expense(Guid userId,
                   string title,
                   decimal amount,
                   DateTime dueData,
                   Category category)
    {
        UserId = userId;
        Title = title;
        Amount = amount;
        IsPaid = false;
        Category = category;
    }

    public Guid UserId { get; private set; }
    public string Title { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime DueDate { get; private set; }
    public DateTime? PaymentDate { get; private set; }
    public bool IsPaid { get; private set; }


    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }


    public void ConfirmPayment(DateTime paymentDate)
    {
        PaymentDate = paymentDate;
        IsPaid = true;
    }
}
