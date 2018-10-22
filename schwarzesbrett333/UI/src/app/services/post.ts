export class Post {
    username: string;
    message: string;
    datum: Date;

    constructor(username: string = '', message: string = '', datum: Date = new Date) {
        this.username = username;
        this.message = message;
        this.datum = datum;
    }
}
