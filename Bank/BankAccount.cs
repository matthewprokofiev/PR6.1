using System;

namespace BankAccountNS
{
    /// <summary>
    /// Класс банковского счёта. Позволяет выполнять операции дебета и кредита.
    /// </summary>
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;

        // Константы для сообщений об ошибках (нужны для рефакторинга тестов)
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
        /// <value>Строка с именем клиента</value>
        public string CustomerName
        {
            get { return m_customerName; }
        }

        /// <summary>
        /// Текущий баланс счёта.
        /// </summary>
        /// <value>Числовое значение баланса</value>
        public double Balance
        {
            get { return m_balance; }
        }

        /// <summary>
        /// Снимает денежные средства со счёта (дебет).
        /// </summary>
        /// <param name="amount">Сумма для снятия</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Возникает, если сумма превышает баланс или меньше нуля.
        /// </exception>
        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }
            m_balance -= amount; // ← исправленная строка (было +=, это баг!)
        }

        /// <summary>
        /// Зачисляет денежные средства на счёт (кредит).
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