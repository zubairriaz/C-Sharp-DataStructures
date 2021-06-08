const Trees = require("./bst");

class Node {
	constructor(key) {
		this.key = key;
		this.left = undefined;
		this.right = undefined;
	}
}


class AVLTree extends Trees.BST {
	constructor() {
		super();
		this.root = null;
	}

	getNodeHeight(node) {
		if (node == null) {
			return -1;
		}
		return (
			Math.max(this.getNodeHeight(node.right), this.getNodeHeight(node.left)) +
			1
		);
	}

	insert(key) {
	
			this.root =  this.insertNode(this.root, key);
		
	}
	insertNode(node, key) {
		if (node == null) {
			return new Node(key);
		}
		if (key > node.key) {
			node.right = this.insertNode(node.right, key);
		}
		else if (key < node.key) {
			node.left = this.insertNode(node.left, key);
		}
      
        const balanceFactor = this.getBalanceFactor(node);
        if(balanceFactor == BalanceFactor.UNBALANCED_LEFT){
            if(key < node.left.key){
                node = this.rotationRR(node);
                console.log(node);
            }else{
                return this.rotationLR(node)
            }
        }
        else if(balanceFactor == BalanceFactor.UNBALANCED_RIGHT){
            if(key > node.right.key){
                node = this.rotationLL(node);
            }else{
                return this.rotationRL(node)
            }
        }
        return node;
	}

	rotationLL(node) {
		let temp = node.right;
		node.right = temp.left;
		temp.left = node;
		return temp;
	}

	rotationRR(node) {
       let temp = node.left;
		node.left = temp.right;
		temp.right = node;
		return temp;
	}

	rotationLR(node) {

		node.left = this.rotationLL(node.left);
        return this.rotationRR(node);
	}
	rotationRL(node) {
		node.right = this.rotationRR(node.right);
		return this.rotationLL(node);
	}

	getBalanceFactor(node) {
		const heightDiffernce =
			this.getNodeHeight(node.left) - this.getNodeHeight(node.right);
		switch (heightDiffernce) {
			case -2:
				return BalanceFactor.UNBALANCED_RIGHT;
			case -1:
				return BalanceFactor.SLIGHTLY_UNBALANCED_RIGHT;
			case 0:
				return BalanceFactor.BALANCED;
			case 1:
				return BalanceFactor.SLIGHTLY_UNBALANCED_LEFT;
			case 2:
				return BalanceFactor.UNBALANCED_LEFT;
		}
	}
}

const BalanceFactor = {
	UNBALANCED_RIGHT: 1,
	SLIGHTLY_UNBALANCED_RIGHT: 2,
	BALANCED: 3,
	SLIGHTLY_UNBALANCED_LEFT: 4,
	UNBALANCED_LEFT: 5,
};

let avl = new AVLTree();
avl.insert(5);
avl.insert(4);
avl.insert(3);
avl.insert(2);
avl.insert(1);
console.log(avl);