using System;
using System.Linq.Expressions;

namespace Application.Common.Extensions
{
    /// <summary>
    /// Содержит методы для композиции предикатов.
    /// </summary>
    /// <remarks>
    /// Исходный код: http://www.albahari.com/nutshell/predicatebuilder.aspx
    /// </remarks>
    public static class PredicateBuilder
    {
        /// <summary>
        /// Возвращает предикат всегда дающий истину. Используется при построении предикатов объединённых условиями И.
        /// </summary>
        /// <typeparam name="T">Тип параметра.</typeparam>
        /// <returns></returns>
        public static Expression<Func<T, bool>> True<T>() { return f => true; }

        /// <summary>
        /// Возвращает предикат всегда дающий ложь. Используется при построении предикатов объединённых условиями ИЛИ.
        /// </summary>
        /// <typeparam name="T">Тип параметра.</typeparam>
        /// <returns></returns>
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        /// <summary>
        /// Объединяет два предиката условием ИЛИ.
        /// </summary>
        /// <typeparam name="T">Тип параметра.</typeparam>
        /// <param name="expr1">Первый предикат.</param>
        /// <param name="expr2">Второй предикат.</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            if (expr1 == null)
                throw new ArgumentNullException(nameof(expr1));

            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters);
            return Expression.Lambda<Func<T, bool>>
                (Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }

        /// <summary>
        /// Объединяет два предиката условием И.
        /// </summary>
        /// <typeparam name="T">Тип параметра.</typeparam>
        /// <param name="expr1">Первый предикат.</param>
        /// <param name="expr2">Второй предикат.</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            if (expr1 == null)
                throw new ArgumentNullException(nameof(expr1));

            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters);
            return Expression.Lambda<Func<T, bool>>
                (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }
    }
}
