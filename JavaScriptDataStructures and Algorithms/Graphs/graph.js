const dictionary = require("../Dictionary/dictionary");
const queue = require("../Queues/queues");
const Queue = queue.Queue;
const Dictionary = dictionary.Dictionary;

class Graph {
	constructor(isDirected = false) {
		this.vertices = [];
		this.adjancyList = new Dictionary();
		this.isDirected = isDirected;
	}

	addVertex(v) {
		if (!this.vertices.includes(v)) {
			this.vertices.push(v);
			this.adjancyList.set(v, []);
		}
	}

	initializeColors() {
		let colors = {};
		for (let i = 0; i < this.vertices.length; i++) {
			colors[this.vertices[i]] = Colors.WHITE;
		}
		return colors;
	}

	getVertices() {
		return this.vertices;
	}

	getAdjList() {
		return this.adjancyList;
	}

	toString() {
		let s = "";
		for (let i = 0; i < this.vertices.length; i++) {
			// {15}
			s += `${this.vertices[i]} -> `;
			const neighbors = this.adjancyList.get(this.vertices[i]).value; // {16}
			for (let j = 0; j < neighbors.length; j++) {
				// {17}
				s += `${neighbors[j]} `;
			}
			s += "\n"; // {18}
		}
		return s;
	}

	breadthFirstSearch(node, callback) {
		let colors = this.initializeColors();
		let queue = new Queue();
		queue.enqueue(node);
		while (queue.getSize() != 0) {
			let item = queue.dequeue();

			let neighbors = this.adjancyList.get(item)?.value;
			colors[item] = Colors.GREY;

			for (let i = 0; i < neighbors.length; i++) {
				if (colors[neighbors[i]] == Colors.WHITE) {
					colors[neighbors[i]] = Colors.GREY;
					queue.enqueue(neighbors[i]);
				}
			}

			colors[item] == Colors.BLACK;
			if (callback) {
				callback(item);
			}
		}
	}

	depthFirstSearch(callback) {
		let colors = this.initializeColors();
		for (let i = 0; i < this.vertices.length; i++) {
			this.depthFirstSearchInner(this.vertices[i], colors, callback);
		}
	}
	depthFirstSearchInner(node, colors, callback) {
		if (colors[node] == Colors.WHITE) {
			colors[node] = Colors.GREY;
			if (callback) {
				callback(node);
			}
		}
		let neighbors = this.adjancyList.get(node).value;

		for (let i = 0; i < neighbors.length; i++) {
			if (colors[neighbors[i]] === Colors.WHITE) {
				this.depthFirstSearchInner(neighbors[i], colors, callback);
			}
		}
		colors[node] = Colors.BLACK;
	}

	addEdge(v, w) {
		if (!this.vertices.includes(v)) {
			this.addVertex(v);
		}
		if (!this.vertices.includes(w)) {
			this.addVertex(w);
		}
		let array = this.adjancyList.get(v).value;
		array.push(w);
		this.adjancyList.set(v, array);
		if (this.isDirected) {
			let array = this.adjancyList.get(w).value;
			array.push(v);
			this.adjancyList.set(w, array);
		}
	}
}

const INF = Number.MAX_SAFE_INTEGER;
const DijakstraAlgo = (graph, src) => {
	const { length } = graph;
	let dist = [];
	let visited = [];
	let parent = [];
	for (let i = 0; i < length; i++) {
		dist[i] = INF;
		visited[i] = false;
	}
	dist[src] = 0;
	parent[src] = -1
	for (let i = 0; i < length; i++) {
		const u = minimumDistance(dist, visited);
		visited[u] = true;
		for (let v = 0; v < length; v++) {
			if(!visited[v] && graph[u][v]!= 0&& dist[u] !== INF && dist[u] + graph[u][v] < dist[v] ){
                  dist[v] = dist[u] + graph[u][v]
				  parent[v] = u
			}
		}
	}
	return parent
};

const minimumDistance = (dist, visited) => {
	let min = INF;
	let minIndex = -1;
	for (let v = 0; v < dist.length; v++) {
		if (visited[v] == false && dist[v] < min) {
			min = dist[v];
			minIndex = v;
		}
	}
	return minIndex;
};

const Colors = {
	WHITE: 0,
	GREY: 1,
	BLACK: 2,
};

// let graph = new Graph(true);
// graph.addVertex("A");
// graph.addVertex("B");
// graph.addEdge("A", "B");
// graph.addEdge("A", "C");
// graph.addEdge("A", "D");
// graph.addEdge("B", "E");
// graph.addEdge("E", "I");
// graph.addEdge("B", "F");

// // console.log(graph.getVertices());
// // console.log(graph.getAdjList());

// const printNode = (value) => console.log(value);

// //graph.breadthFirstSearch("B",printNode)
// graph.depthFirstSearch(printNode);

const graph = [[0, 2, 6, 0, 0, 0], 
[0, 0, 2, 4, 2, 0], 
[0, 0, 0, 0, 3, 0], 
[0, 0, 0, 0, 0, 2], 
[0, 0, 0, 3, 0, 2], 
[0, 0, 0, 0, 0, 0]]; 

console.log(DijakstraAlgo(graph, 0));
