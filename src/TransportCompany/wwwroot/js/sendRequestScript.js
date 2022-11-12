document.getElementById("createOrderBtn").addEventListener("click", async () => {
    const firstName = document.getElementById("userFirstName").value;
    const lastName = document.getElementById("userLastName").value;
    const phoneNumber = document.getElementById("userPhoneNumber").value;
    const sendAddress = document.getElementById("userSendAddress").value;
    const deliveryAddress = document.getElementById("userDeliveryAddress").value;
    const commentMessage = document.getElementById("userCommentMessage").value;
    if (firstName === "" || lastName === "" || phoneNumber === "" || sendAddress === "" || deliveryAddress === "") {
        alert("Все поля, кроме сообщения обязательны для заполнения!");
    } else if (phoneNumber.length != 10 && !(phoneNumber instanceof Number)) {
        alert("Номер телефона должен состоять из 10 цифр! Вводите его без +7 или 8! Так же телефон должен состоять только из цифр!");
    } else {
        const response = await fetch("/api/orders", {
            method: "POST",
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            body: JSON.stringify({
                firstName: firstName,
                lastName: lastName,
                phoneNumber: phoneNumber,
                sendAddress: sendAddress,
                deliveryAddress: deliveryAddress,
                commentMessage: commentMessage,
            })
        });
        if (response.ok === true) {
            alert("Ваша заявка принята! Дождитесь обратного звонка от нашего оператора!");
            location.reload();
        } else {
            const error = await response.json();
            console.log(error.message);
        }
    }
});