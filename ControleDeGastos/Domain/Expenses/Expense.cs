using Core.BaseTypes;
using Domain.Categories;
using Domain.Users;

namespace Domain.Expenses;
public class Expense : BaseClass<Guid>
{
    public Expense(Guid userId,
                   string title,
                   decimal amount,
                   DateTime dueDate,
                   int categoryId
                   )
    {
        UserId = userId;
        Title = title;
        DueDate = dueDate;
        Amount = amount;        
        CategoryId = categoryId;
        IsPaid = false;
        PaymentDate = null;
    }
    
    public string Title { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime DueDate { get; private set; }
    public DateTime? PaymentDate { get; private set; }
    public bool IsPaid { get; private set; }


    public Guid UserId { get; private set; }
    public User User { get; private set; }

    public int CategoryId { get; private set; }
    public Category Category { get; private set; }


    public void ConfirmPayment(DateTime paymentDate)
    {
        PaymentDate = paymentDate;
        IsPaid = true;
    }
}
