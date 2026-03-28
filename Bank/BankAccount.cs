using System;

namespace BankAccountNS
{
    /// <summary>
    /// Bank account demo class.
    /// </summary>
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;

        // Рефакторинг тестируемого кода. Пункт 1.
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";

        private BankAccount() { }

        /// <summary>
        /// Создаёт новый банковский счёт.
        /// </summary>
        /// <param name="customerName">Имя владельца счёта</param>
        /// <param name="balance">Начальный баланс счёта</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        /// <summary>
        /// Имя владельца счёта.
        /// </summary>
        public string CustomerName
        {
            get { return m_customerName; }
        }

        /// <summary>
        /// Текущий баланс счёта.
        /// </summary>
        public double Balance
        {
            get { return m_balance; }
        }

        /// <summary>
        /// Снимает денежные средства со счёта.
        /// </summary>
        /// <param name="amount">Сумма для снятия</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Возникает, если сумма превышает баланс или меньше нуля.
        /// </exception>
        public void Debit(double amount)
        {
            // Рефакторинг тестируемого кода. Пункт 2.
            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }
            // Создание и запуск метода теста. Пункт 3.
            m_balance -= amount;
        }

        /// <summary>
        /// Зачисляет денежные средства на счёт.
        /// </summary>
        /// <param name="amount">Сумма для зачисления</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Возникает, если сумма меньше нуля.
        /// </exception>
        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, "Credit amount is less than zero");
            }
            m_balance += amount;
        }

        /// <summary>
        /// Точка входа в программу. Демонстрирует работу счёта.
        /// </summary>
        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Roman Abramovich", 11.99);
            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
            Console.ReadLine();
        }
    }
}