using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab12;
using ShapesLib;

namespace Lab12_Tree_TESTS
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BalancedTree_InvalidSIze()
        {
            TPoint<Circle> tree = new TPoint<Circle>();
            tree = Tree<Circle>.BalancedTree(0);
            Assert.IsNull(tree);
        }

        [TestMethod]
        public void BalancedTree_ValidSize()
        {
            TPoint<Circle> tree = new TPoint<Circle>();
            tree = Tree<Circle>.BalancedTree(5);
            Assert.IsNotNull(tree);
        }

        [TestMethod]
        public void BalancedTree_NegativeSize()
        {
            TPoint<Circle> tree = new TPoint<Circle>();
            tree = Tree<Circle>.BalancedTree(-1);
            Assert.IsNull(tree);
        }

        [TestMethod]
        public void SortedTree_Create()
        {
            // Create an unbalanced tree
            var root = new TPoint<Circle>(new Circle("A", 10.0));
            root.left = new TPoint<Circle>(new Circle("B", 5.0));
            root.left.left = new TPoint<Circle>(new Circle("C", 2.0));
            root.left.right = new TPoint<Circle>(new Circle("D", 7.0));
            root.right = new TPoint<Circle>(new Circle("E", 15.0));
            var tree = new Tree<Circle>(root);
            Tree<Circle>.size = 5;

            // Create sorted tree
            var sortedTree = Tree<Circle>.SortedTree(tree);

            // Verify the root is the middle element (should be 7.0)
            Assert.AreEqual(7.0, sortedTree.root.data.Radius);
            // Verify left subtree
            Assert.AreEqual(5.0, sortedTree.root.left.data.Radius);
            Assert.AreEqual(2.0, sortedTree.root.left.left.data.Radius);
            // Verify right subtree
            Assert.AreEqual(10.0, sortedTree.root.right.data.Radius);
            Assert.AreEqual(15.0, sortedTree.root.right.right.data.Radius);
        }
    }
}
