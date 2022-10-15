class List{
    constructor(){
        this.sortedList = [];
        this.size = 0;
    }
    
    add(element) {
        this.sortedList.push(element);
        this.sortedList.sort((a, b) => a - b);
        this.size++;
    }
    
    remove(index) {
        if(index < 0 || index >= this.size){
        throw new Error(`Incorrect index!`);
        }
        this.sortedList.splice(index, 1);
        this.size--;
    }

    get(index) {
        if(index < 0 || index >= this.size){
            throw new Error(`Incorrect index!`);
        }
        return this.sortedList[index];
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));
