﻿using System;
using System.Collections.Generic;
using System.Text;

//-------------------------------------------------------------------------------------------------------
//Question BST Construction: AlgoExpert
//Write a BST class for a Binary Search Tree.The class should support:

//  - Inserting values with the insert method.
//  - Removing values with the remove method; this method should only remove the first instance of a given value.
//  - Searching for values with the contains method.

//Note that you can't remove values from a single-node tree. In other words, calling the remove method on a single-node tree should simply not do anything.

//Each BST node has an integer value, a left child node, and a right child node.
//A node is said to be a valid BST node if and only if it satisfies the BST property:
//  -its value is strictly greater than the values of every node to its left;
//  -its value is less than or equal to the values of every node to its right;
//  -and its children nodes are either valid BST nodes themselves or None / null.

//Sample Usage

// Assume the following BST has already been created :

//            10
//          /    \
//         5      15
//        / \    /   \
//      2    5  13   22
//     /          \
//    1            14       

// All operations below are performed sequentially.

//insert(12):

//            10
//          /    \
//         5      15
//        / \    /   \
//      2    5  13   22
//     /       /  \
//    1       12   14       


//remove(10):

//            12
//          /    \
//         5      15
//        / \    /   \
//      2    5  13   22
//     /          \
//    1           14       


//contains(15) : true

//            12
//          /    \
//         5      15
//        / \    /   \
//      2    5  13   22
//     /          \
//    1           14                                              
//-------------------------------------------------------------------------------------------------------

namespace AmazonStack
{
    public class BSTOperation
    {
		public class BST
		{
			public int value;
			public BST left;
			public BST right;

			public BST(int value)
			{
				this.value = value;
			}
			//Average: O(log(n)) time | O(1) space
			//worst: O(n) time | O(1) space
			public BST Insert(int value, BST root)
			{
				BST newNode = new BST(value);
				var current = root;
				//BST root;
				while (current != null)
				{
					if (value < current.value)
					{
						if (current.left == null)
						{
							current.left = newNode;
							break;
						}
						else
						{
							current = current.left;;
						}
					}
					else
					{
						if (current.right == null)
						{
							current.right = newNode;
							break;
						}
						else
						{
							current = current.right;
						}
					}
				}
				return this;
			}

			//Average: O(log(n)) time | O(1) space
			//worst: O(n) time | O(1) space
			public bool Contains(int value, BST root)
			{
				var current = root;
				while (current != null)
				{
					if (current.value == value)
					{
						return true;
					}
					else if (value > current.value)
					{
						current = current.right;
					}
					else
					{
						current = current.left;
					}
				}
				return false;
			}

			//Average: O(log(n)) time | O(1) space
			//worst: O(n) time | O(1) space
			public BST Remove(int value)
			{
				Remove(value, null);
				return this;
			}

			public void Remove(int value, BST parentNode)
			{
				BST current = this;
				while (current != null)
				{
					if (value < current.value)
					{
						parentNode = current;
						current = current.left;
					}
					else if (value > current.value)
					{
						parentNode = current;
						current = current.right;
					}
					else
					{
						//when both nodes exists
						if (current.left != null && current.right != null)
						{
							var minRight = current.right;
							while (minRight.left != null)
							{
								minRight = minRight.left;
							}
							current.value = minRight.value;
							current.right.Remove(minRight.value, current);
							//break;
						}

						//when parent noden has only one child
						else if (parentNode == null)
						{
							if (current.left != null)
							{
								var leftNode = current.left;
								current.value = leftNode.value;
								current.left = leftNode.left;
								current.right = leftNode.right;
								//break;
							}
							else if (current.right != null)
							{
								var rightNode = current.right;
								current.value = rightNode.value;
								current.left = rightNode.left;
								current.right = rightNode.right;
								//break;
							}
							else
							{
							}
						}
						//not parent but has only left child
						else if (parentNode.left == current)
						{
							//parentNode.left = current.left ?? current.right;
							parentNode.left = current.left != null ? current.left : current.right;
						}
						else if (parentNode.right == current)
						{
							//parentNode.right = current.left ?? current.right;
							parentNode.right = current.left != null ? current.left : current.right;
						}
						break;
					}
				}
			}
		}
	}
}
