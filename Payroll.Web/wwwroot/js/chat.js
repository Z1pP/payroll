
var connection = new signalR.HubConnectionBuilder().withUrl("/chat").build();

document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message, sendTime) {
    var ul = document.getElementById("messagesList");
    var li = document.createElement("li");
    var messageDiv = document.createElement("div");
    var timeDiv = document.createElement("div");
    var nameDiv = document.createElement("div");

    if (user === "@empl.Name") {
        li.classList.add("message-right"); //выравнивание сообщения сотрудника по правому краю
    } else {
        li.classList.add("message-left"); //сообщение остальных слева
        nameDiv.textContent = user; 
        li.appendChild(nameDiv);
    }

    messageDiv.textContent = message;
    timeDiv.textContent = sendTime;
    timeDiv.classList.add("time");

    li.classList.add("message");
    li.appendChild(timeDiv);
    li.appendChild(messageDiv);

    ul.appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = "@empl.Name";
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});