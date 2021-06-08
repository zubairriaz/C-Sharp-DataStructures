class Node {
	constructor(key) {
		this.key = key;
		this.left = undefined;
		this.right = undefined;
	}
}

module.exports.BST = class BST {
	constructor() {
		this.root = null;
	}

	insert(key) {
		let node = new Node(key);
		if (this.root == null) {
			this.root = node;
		} else {
			let head = this.root;
			this.insertNode(head, key);
		}
	}

    remove(key){
        this.removeNode(this.root, key);
    }

    removeNode(node, key){
        if(node == null){
            return
        }
        if(node.key > key){
            node.left = this.removeNode(node.left, key);
            return node; 
        }else if(node.key < key){
            node.right = this.removeNode(node.right, key);
            return node;
        }
        else{
            if(node.left == null && node.right ==null){
                node = null;
                return node;
            }
            else if(node.left == null){
                node = node.right;
                return node;
            }
            else if(node.right == null){
                node = node.left;
                return node;
            }
            else{
                const aux = this.minValue(node.right);
                node.key = aux.key;
                node.right = this.removeNode(node.right , aux.key);
                return node;
            }
        }
    }
    
    getNode(key){
        let current = this.root;
        while(current != null && current.key != key && current.key < key ){
            current = current.right;
        }
        while(current != null && current.key != key && current.key > key ){
            current = current.left;
        }
        if(current != null && current.key == key){
            return current;
        }else{
             return false
        }
    }

    getMinValue(){
          return this.minValue(this.root)
    }

    getMaxValue(){
        let current = this.root;
        while(current != null && current.right != null){
            current = current.right;
        }
        return current;

    }
   
    minValue(node){
        if(node.left == null){
            return node
        }
        return this.minValue(node.left);
    }

	postOrderSearch(callback) {
		this.postOrderTraversal(this.root, callback);
	}

	preOrderSearch(callback) {
		this.preOrderTraversal(this.root, callback);
	}

	preOrderTraversal(node, callback) {
		if (node == null) {
			return;
		}
		callback(node.key);
		this.preOrderTraversal(node.left, callback);
		this.preOrderTraversal(node.right, callback);
	}

	postOrderTraversal(node, callback) {
		if (node == null) {
			return;
		}
		this.postOrderTraversal(node.left, callback);
		this.postOrderTraversal(node.right, callback);
		callback(node.key);
	}

	InOrderSearch(callback) {
		this.InorderTraversal(this.root, callback);
	}

	InorderTraversal(node, callback) {
		if (node == null) {
			return;
		}
		this.InorderTraversal(node.left, callback);

		callback(node.key);

		this.InorderTraversal(node.right, callback);
	}

	insertNode(node, key) {
        if(node == null){
            return new Node(key);
        }
        if(key > node.key){
            node.right = this.insertNode(node.right , key)
            return node;
        }else{
            node.left = this.insertNode(node.left , key)
            return node;

        }
		// if (key > node.key) {
		// 	if (node.right == null) {
		// 		node.right = new Node(key);
		// 	} else {
		// 		this.insertNode(node.right, key);
		// 	}
		// } else {
		// 	if (node.left == null) {
		// 		node.left = new Node(key);
		// 	} else {
		// 		this.insertNode(node.left, key);
		// 	}
		// }
	}
}

// const trr = new BST();

// trr.insert(5);
// trr.insert(4);
// trr.insert(3);
// trr.insert(6);
// trr.insert(7);
// const printNode = (value) => console.log(value); // {6}
// // trr.InOrderSearch(printNode);
// // trr.postOrderSearch(printNode);
// //trr.preOrderSearch(printNode)
// // console.log(trr.getMinValue())
// // console.log(trr.getMaxValue())
// //console.log(trr.remove(3))
// console.log(trr);

