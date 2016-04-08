﻿#region License
/**
 * Copyright (c) 2015, 何志祥 (strangecity@qq.com).
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * without warranties or conditions of any kind, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#endregion

using System;
using System.Linq.Expressions;

namespace Expression2Sql
{
    internal class Expression2SqlProvider
    {
        private static IExpression2Sql GetExpression2Sql(Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression", "Cannot be null");
            }

            if (expression is BinaryExpression)
            {
                return new BinaryExpression2Sql();
            }
            if (expression is BlockExpression)
            {
                throw new NotImplementedException("Unimplemented BlockExpression2Sql");
            }
            if (expression is ConditionalExpression)
            {
                throw new NotImplementedException("Unimplemented ConditionalExpression2Sql");
            }
            if (expression is ConstantExpression)
            {
                return new ConstantExpression2Sql();
            }
            if (expression is DebugInfoExpression)
            {
                throw new NotImplementedException("Unimplemented DebugInfoExpression2Sql");
            }
            if (expression is DefaultExpression)
            {
                throw new NotImplementedException("Unimplemented DefaultExpression2Sql");
            }
            if (expression is DynamicExpression)
            {
                throw new NotImplementedException("Unimplemented DynamicExpression2Sql");
            }
            if (expression is GotoExpression)
            {
                throw new NotImplementedException("Unimplemented GotoExpression2Sql");
            }
            if (expression is IndexExpression)
            {
                throw new NotImplementedException("Unimplemented IndexExpression2Sql");
            }
            if (expression is InvocationExpression)
            {
                throw new NotImplementedException("Unimplemented InvocationExpression2Sql");
            }
            if (expression is LabelExpression)
            {
                throw new NotImplementedException("Unimplemented LabelExpression2Sql");
            }
            if (expression is LambdaExpression)
            {
                throw new NotImplementedException("Unimplemented LambdaExpression2Sql");
            }
            if (expression is ListInitExpression)
            {
                throw new NotImplementedException("Unimplemented ListInitExpression2Sql");
            }
            if (expression is LoopExpression)
            {
                throw new NotImplementedException("Unimplemented LoopExpression2Sql");
            }
            if (expression is MemberExpression)
            {
                return new MemberExpression2Sql();
            }
            if (expression is MemberInitExpression)
            {
                throw new NotImplementedException("Unimplemented MemberInitExpression2Sql");
            }
            if (expression is MethodCallExpression)
            {
                return new MethodCallExpression2Sql();
            }
            if (expression is NewArrayExpression)
            {
                return new NewArrayExpression2Sql();
            }
            if (expression is NewExpression)
            {
                return new NewExpression2Sql();
            }
            if (expression is ParameterExpression)
            {
                return new ParameterExpression2Sql();
            }
            if (expression is RuntimeVariablesExpression)
            {
                throw new NotImplementedException("Unimplemented RuntimeVariablesExpression2Sql");
            }
            if (expression is SwitchExpression)
            {
                throw new NotImplementedException("Unimplemented SwitchExpression2Sql");
            }
            if (expression is TryExpression)
            {
                throw new NotImplementedException("Unimplemented TryExpression2Sql");
            }
            if (expression is TypeBinaryExpression)
            {
                throw new NotImplementedException("Unimplemented TypeBinaryExpression2Sql");
            }
            if (expression is UnaryExpression)
            {
                return new UnaryExpression2Sql();
            }

            throw new NotImplementedException("Unimplemented Expression2Sql");
        }

        public static void Insert(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).Insert(expression, sqlBuilder);
        }

        public static void Update(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).Update(expression, sqlBuilder);
        }

        public static void Select(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).Select(expression, sqlBuilder);
        }

        public static void Join(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).Join(expression, sqlBuilder);
        }

        public static void Where(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).Where(expression, sqlBuilder);
        }

        public static void In(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).In(expression, sqlBuilder);
        }

        public static void GroupBy(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).GroupBy(expression, sqlBuilder);
        }

        public static void OrderBy(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).OrderBy(expression, sqlBuilder);
        }

        public static void Max(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).Max(expression, sqlBuilder);
        }

        public static void Min(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).Min(expression, sqlBuilder);
        }

        public static void Avg(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).Avg(expression, sqlBuilder);
        }

        public static void Count(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).Count(expression, sqlBuilder);
        }

        public static void Sum(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).Sum(expression, sqlBuilder);
        }
    }
}
