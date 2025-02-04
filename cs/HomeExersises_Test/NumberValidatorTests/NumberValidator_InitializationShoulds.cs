﻿using System;
using FluentAssertions;
using NUnit.Framework;
using HomeExercises;

namespace HomeExersises_Test
{
    [TestFixture]
    public class NumberValidator_InitializationShould
    {
        [TestCase(0, 0, true, TestName = "Throw_WhenZeroPrecision")]
        [TestCase(-1, 0, true, TestName = "Throw_WhenNegativePrecision")]
        public void Throw_WhenPrecisionIsNegativeOrZero(int precision, int scale, bool onlyPositive)
        {
            Action validatorInit = () => new NumberValidator(precision, scale, onlyPositive);
            validatorInit.Should()
                .Throw<ArgumentException>()
                .WithMessage("precision must be a positive number");
        }

        [TestCase(1, -1, true, TestName = "Throw_WhenNegativeScale")]
        [TestCase(1, 2, true, TestName = "Throw_WhenScaleGreaterThanPrecision")]
        public void Throw_WhenScaleIsNegativeOrGreaterThanPrec(int precision, int scale, bool onlyPositive)
        {
            Action validatorInit = () => new NumberValidator(precision, scale, onlyPositive);
            validatorInit.Should()
                .Throw<ArgumentException>()
                .WithMessage("scale must be a non-negative number less or equal than precision");
        }

        [Test]
        public void NotThrow_OnCorrectInput_AllArguements()
        {
            Action validatorInit = () => new NumberValidator(8, 2, true);
            validatorInit.Should().NotThrow();
        }

        [Test]
        public void NotTwhrow_OnCorrectInput_WitoutOptionalArguement_OnlyPositive()
        {
            Action validatorInit = () => new NumberValidator(8, 2);
            validatorInit.Should().NotThrow();
        }

        [Test]
        public void NotTwhrow_OnCorrectInput_WitoutOptionalArguement_Scale()
        {
            Action validatorInit = () => new NumberValidator(8, onlyPositive: true);
            validatorInit.Should().NotThrow();
        }

        [Test]
        public void NotTwhrow_OnCorrectInput_WitoutOptionalArguements_Scale_And_OnlyPositive()
        {
            Action validatorInit = () => new NumberValidator(8);
            validatorInit.Should().NotThrow();
        }

        public void NotTwhrow_OnCorrectInput_ScaleEqualsPrecision()
        {
            Action validatorInit = () => new NumberValidator(1, 1);
            validatorInit.Should().NotThrow();
        }
    }
}