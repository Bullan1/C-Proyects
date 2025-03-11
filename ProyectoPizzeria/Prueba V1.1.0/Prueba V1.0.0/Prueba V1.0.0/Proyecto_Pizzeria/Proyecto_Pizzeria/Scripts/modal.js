document.addEventListener('DOMContentLoaded', function () {
    // Obtener el modal
    var modal = document.getElementById("carritoModal");

    // Obtener el botón que abre y cierra el modal
    var btn = document.getElementById("carritoBtn");

    // Obtener el elemento <span> que cierra el modal
    var span = document.getElementsByClassName("close")[0];

    // Manejar el clic en el botón de carrito para abrir y cerrar el modal
    btn.addEventListener('click', function () {
        if (modal.style.display === "block") {
            modal.style.display = "none";
        } else {
            modal.style.display = "block";
            updateCart();
            // Actualizar el carrito cada 5 segundos (5000 milisegundos)
            setInterval(updateCart, 5000);
        }
    });

    // Cuando el usuario hace clic en <span> (x), cierra el modal
    span.onclick = function () {
        modal.style.display = "none";
    }

    // Cuando el usuario hace clic en cualquier lugar fuera del modal, cierra el modal
    window.onclick = function (event) {
        if (event.target == modal && modal.style.display === "block") {
            modal.style.display = "none";
        }
    }

    // Lista de elementos en el carrito
    var cart = [];

    // Manejar la adición de productos al carrito
    var addToCartButtons = document.querySelectorAll('.add-to-cart');
    addToCartButtons.forEach(function (button) {
        button.addEventListener('click', function () {
            var id = this.dataset.id;
            var name = this.dataset.name;
            var price = parseFloat(this.dataset.price); // Asegúrate de que el precio se maneje como número

            cart.push({ id: id, name: name, price: price });
            updateCart(); // Actualizar el carrito al agregar un elemento
        });
    });

    // Manejar la eliminación de productos del carrito
    function removeFromCart(index) {
        cart.splice(index, 1);
        updateCart();
    }

    // Actualizar la lista del carrito en el modal
    function updateCart() {
        var cartItems = document.getElementById('cartItems');
        cartItems.innerHTML = '';

        var total = 0;
        cart.forEach(function (item, index) {
            var li = document.createElement('li');
            li.textContent = item.name + " - $" + item.price.toFixed(3);
            li.classList.add('cart-item'); // Agregamos la clase .cart-item

            var removeButton = document.createElement('button');
            removeButton.innerHTML = "&times";
            removeButton.classList.add('remove-button');
            removeButton.onclick = function () {
                removeFromCart(index);
            };

            li.appendChild(removeButton);
            cartItems.appendChild(li);

            total += item.price;
        });

        // Actualizar el precio total
        document.getElementById('totalPrice').textContent = total.toFixed(3);
    }

    // Variables para arrastrar el modal
    var pos1 = 0, pos2 = 0, pos3 = 0, pos4 = 0;

    // Función para iniciar el arrastre
    function dragMouseDown(e) {
        e = e || window.event;
        e.preventDefault();
        // Obtener la posición inicial del cursor
        pos3 = e.clientX;
        pos4 = e.clientY;
        // Agregar eventos de arrastre y suelta
        document.onmousemove = elementDrag;
        document.onmouseup = closeDragElement;
    }

    // Función para arrastrar el modal
    function elementDrag(e) {
        e = e || window.event;
        e.preventDefault();
        // Calcular la nueva posición del modal
        pos1 = pos3 - e.clientX;
        pos2 = pos4 - e.clientY;
        pos3 = e.clientX;
        pos4 = e.clientY;
        // Establecer la nueva posición del modal
        modal.style.top = (modal.offsetTop - pos2) + "px";
        modal.style.left = (modal.offsetLeft - pos1) + "px";
    }

    // Función para detener el arrastre
    function closeDragElement() {
        // Detener el arrastre al soltar el mouse
        document.onmouseup = null;
        document.onmousemove = null;
    }

    // Agregar evento para iniciar el arrastre al hacer clic en el encabezado del modal
    document.getElementById("carritoModal").getElementsByClassName("modal-content")[0].onmousedown = dragMouseDown;
});

