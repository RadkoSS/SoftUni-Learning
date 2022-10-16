class Contact{
    constructor(firstName, lastName, phone, email){
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.email = email;
        this.online = false;
    }

    get online(){
        return this._online;
    }

    set online(value){
        this._online = value;

        if(this.onlineDiv){
            this.onlineDiv.className = this.online ? `title online` : `title`;
        }
    }
    
    elementFactory(tag, content = ``){
        const element = document.createElement(tag);
		element.innerHTML = content;

		return element;
    }

    render(id){
        this.article = this.elementFactory(`article`);
        this.onlineDiv = this.elementFactory(`div`, `${this.firstName} ${this.lastName}`);
        this.infoButton = this.elementFactory(`button`, `&#8505;`);

        this.infoDiv = this.elementFactory(`div`, `<span>&phone; ${this.phone}</span>`);
        this.infoDiv.innerHTML += `&#9993; ${this.email}`;
        
        this.onlineDiv.className = this.online ? `online title` : `title`;
        
        this.infoDiv.className = `info`;
        this.infoDiv.style.display = `none`;

        this.onlineDiv.appendChild(this.infoButton);
        this.article.appendChild(this.onlineDiv);
        this.article.appendChild(this.infoDiv);
        
        document.getElementById(id).appendChild(this.article);

        this.infoButton.addEventListener(`click`, () => {
            this.infoDiv.style.display = this.infoDiv.style.display === `none` ? `block` : `none`;
        });
    }
}

//Test code...

let contacts = [
    new Contact("Radoslav", "Gervaziev", "0888 123 456", "radi7275@gmail.com"),
    new Contact("Maria", "Petrova", "0899 987 654", "mar4eto@abv.bg"),
    new Contact("Jordan", "Kirov", "0988 456 789", "jordk@gmail.com")
  ];
  contacts.forEach(c => c.render('main'));
  
  // After 1 second, change the online status to true

  setTimeout(() => contacts[0].online = true, 3000);
  setTimeout(() => contacts[1].online = true, 5000);
  setTimeout(() => contacts[2].online = true, 7000);
  