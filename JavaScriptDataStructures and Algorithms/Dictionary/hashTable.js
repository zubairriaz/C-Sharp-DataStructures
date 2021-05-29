const stringFnEqual = (item) => {
	let returnValue;
	if (item == null) {
		returnValue = "NULL";
	} else if (item == undefined) {
		returnValue = "UNDEFINED";
	} else if (typeof item == "string" || item instanceof String) {
		returnValue = `${item}`;
	} else {
		returnValue = `${item}`;
	}

	return returnValue;
};

class HashTable {
	constructor(defaultEqFn = defaultEqFn) {
		this.strEqFn = defaultEqFn;
		this.table = {};
	}
	put(key, value) {
		const hash = this.hash(key);
		if (!this.table.hasOwnProperty(hash)) {
			this.table[hash] = value;
			return true;
		}
		return false;
	}
	remove(key) {}
	get(key) {}

	hash(key) {
		return this.looseLooseHash(key);
	}

	looseLooseHash(key) {
		if (typeof key == "number") {
			return key;
		} else {
			let hash = 0;
			const keyHash = this.strEqFn(key);
			for (let i = 0; i <= keyHash.length; i++) {
				hash += keyHash.charCodeAt(i);
			}
			return hash % 37;
		}
	}
}
