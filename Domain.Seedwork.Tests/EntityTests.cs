﻿//===================================================================================
// Microsoft Developer & Platform Evangelism
//=================================================================================== 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// Copyright (c) Microsoft Corporation.  All Rights Reserved.
// This code is released under the terms of the MS-LPL license, 
// http://microsoftnlayerapp.codeplex.com/license
//===================================================================================

using System;

using Domain.Seedwork.Tests.Classes;

using Microsoft.Samples.NLayerApp.Domain.Seedwork;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Seedwork.Tests
{

   [TestClass()]
   public class EntityTests
   {

      [TestMethod()]
      public void SameIdentityProduceEqualsTrueTest()
      {
         //Arrange
         var id = Guid.NewGuid();

         var entityLeft = new SampleEntity();
         var entityRight = new SampleEntity();

         entityLeft.ChangeCurrentIdentity(id);
         entityRight.ChangeCurrentIdentity(id);

         //Act
         var resultOnEquals = entityLeft.Equals(entityRight);
         var resultOnOperator = entityLeft == entityRight;

         //Assert
         Assert.IsTrue(resultOnEquals);
         Assert.IsTrue(resultOnOperator);

      }

      [TestMethod()]
      public void DiferentIdProduceEqualsFalseTest()
      {
         //Arrange

         var entityLeft = new SampleEntity();
         var entityRight = new SampleEntity();

         entityLeft.GenerateNewIdentity();
         entityRight.GenerateNewIdentity();

         //Act
         var resultOnEquals = entityLeft.Equals(entityRight);
         var resultOnOperator = entityLeft == entityRight;

         //Assert
         Assert.IsFalse(resultOnEquals);
         Assert.IsFalse(resultOnOperator);

      }

      [TestMethod()]
      public void CompareUsingEqualsOperatorsAndNullOperandsTest()
      {
         //Arrange

         SampleEntity entityLeft = null;
         var entityRight = new SampleEntity();

         entityRight.GenerateNewIdentity();

         //Act
         if (!(entityLeft == (Entity) null)) //this perform ==(left,right)
         { Assert.Fail(); }

         if (!(entityRight != (Entity) null)) //this perform !=(left,right)
         { Assert.Fail(); }

         entityRight = null;

         //Act
         if (!(entityLeft == entityRight)) //this perform ==(left,right)
         { Assert.Fail(); }

         if (entityLeft != entityRight) //this perform !=(left,right)
         { Assert.Fail(); }

      }

      [TestMethod()]
      public void CompareTheSameReferenceReturnTrueTest()
      {
         //Arrange
         var entityLeft = new SampleEntity();
         var entityRight = entityLeft;

         //Act
         if (!entityLeft.Equals(entityRight)) { Assert.Fail(); }

         if (!(entityLeft == entityRight)) { Assert.Fail(); }

      }

      [TestMethod()]
      public void CompareWhenLeftIsNullAndRightIsNullReturnFalseTest()
      {
         //Arrange

         SampleEntity entityLeft = null;
         var entityRight = new SampleEntity();

         entityRight.GenerateNewIdentity();

         //Act
         if (!(entityLeft == (Entity) null)) //this perform ==(left,right)
         { Assert.Fail(); }

         if (!(entityRight != (Entity) null)) //this perform !=(left,right)
         { Assert.Fail(); }
      }

      [TestMethod()]
      public void SetIdentitySetANonTransientEntity()
      {
         //Arrange
         var entity = new SampleEntity();

         //Act
         entity.GenerateNewIdentity();

         //Assert
         Assert.IsFalse(entity.IsTransient());
      }

      [TestMethod()]
      public void ChangeIdentitySetNewIdentity()
      {
         //Arrange
         var entity = new SampleEntity();
         entity.GenerateNewIdentity();

         //act
         var expected = entity.Id;
         entity.ChangeCurrentIdentity(Guid.NewGuid());

         //assert
         Assert.AreNotEqual(expected, entity.Id);
      }

   }

}