// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Variables para el saldo y el historial de operaciones
let balance = 0;
let history = [];
let clients = []; // Historial de clientes

// Elementos del DOM
const loginContainer = document.getElementById('login-container');
const walletContainer = document.getElementById('wallet-container');
const emailInput = document.getElementById('email');
const dniInput = document.getElementById('dni');
const passwordInput = document.getElementById('password');
const showPasswordCheckbox = document.getElementById('showPassword');
const loginBtn = document.getElementById('loginBtn');
const welcomeMessage = document.getElementById('welcome-message');
const balanceDisplay = document.getElementById('balance');
const historyList = document.getElementById('history');
const alertMessage = document.getElementById('alert-message'); // Contenedor de alertas
const clientHistoryList = document.getElementById('clientHistory');

// Modal y sus botones
const historyModal = document.getElementById('historyModal');
const clientHistoryModal = document.getElementById('clientHistoryModal');
const historyBtn = document.getElementById('historyBtn');
const clientHistoryBtn = document.getElementById('clientHistoryBtn');
const closeModal = document.getElementsByClassName('close');

// Botón para volver al login
const backBtn = document.getElementById('backBtn');

// Mostrar contraseña
showPasswordCheckbox.addEventListener('change', () => {
    passwordInput.type = showPasswordCheckbox.checked ? 'text' : 'password';
});

// Función de login con validaciones
loginBtn.addEventListener('click', () => {
    const email = emailInput.value;
    const dni = dniInput.value;
    const password = passwordInput.value;

    // Validaciones
    const dniPattern = /^\d{8}$/; // 8 dígitos
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/; // Formato de email

    alertMessage.style.display = 'none'; // Ocultar mensaje previo

    if (!dniPattern.test(dni)) {
        alertMessage.textContent = 'El DNI debe ser exactamente 8 dígitos.';
        alertMessage.style.display = 'block'; // Mostrar mensaje
        return;
    }

    if (!emailPattern.test(email)) {
        alertMessage.textContent = 'El correo electrónico no es válido. Debe contener "@" y un dominio.';
        alertMessage.style.display = 'block'; // Mostrar mensaje
        return;
    }

    if (email && dni && password) {
        // Agregar cliente al historial
        clients.push({ email, dni });

        // Mostrar billetera
        loginContainer.style.display = 'none';
        welcomeMessage.textContent = `Bienvenido, ${email}`;
        walletContainer.style.display = 'block';
    } else {
        alertMessage.textContent = 'Por favor, completa todos los campos.';
        alertMessage.style.display = 'block'; // Mostrar mensaje
    }
});

// Botón de regreso al login
backBtn.addEventListener('click', () => {
    walletContainer.style.display = 'none';
    loginContainer.style.display = 'block';
});

// Funciones de la billetera
document.getElementById('addMoneyBtn').addEventListener('click', () => {
    const amount = parseFloat(prompt('Ingrese el monto a agregar:'));
    if (!isNaN(amount) && amount > 0) {
        balance += amount;
        balanceDisplay.textContent = balance;
        history.push(`Se agregó: $${amount}`);
    } else {
        alert('Monto inválido.');
    }
});

document.getElementById('consultBtn').addEventListener('click', () => {
    alert(`Su saldo actual es: $${balance}`);
});

document.getElementById('modifyBtn').addEventListener('click', () => {
    const newBalance = parseFloat(prompt('Ingrese el nuevo saldo:'));
    if (!isNaN(newBalance)) {
        balance = newBalance;
        balanceDisplay.textContent = balance;
        history.push(`Saldo modificado a: $${newBalance}`);
    } else {
        alert('Monto inválido.');
    }
});

document.getElementById('deleteMoneyBtn').addEventListener('click', () => {
    const amount = parseFloat(prompt('Ingrese el monto a eliminar:'));
    if (!isNaN(amount) && amount > 0 && amount <= balance) {
        balance -= amount;
        balanceDisplay.textContent = balance;
        history.push(`Se eliminó: $${amount}`);
    } else {
        alert('Monto inválido.');
    }
});

// Mostrar historial de operaciones
historyBtn.addEventListener('click', () => {
    historyModal.style.display = 'block';
    historyModal.style.opacity = 0; // Iniciar con opacidad 0
    setTimeout(() => {
        historyModal.style.opacity = 1; // Cambiar a opacidad 1
    }, 10); // Pequeño retraso para aplicar la transición
    updateHistoryDisplay();
});

// Mostrar historial de clientes
clientHistoryBtn.addEventListener('click', () => {
    clientHistoryModal.style.display = 'block';
    clientHistoryModal.style.opacity = 0; // Iniciar con opacidad 0
    setTimeout(() => {
        clientHistoryModal.style.opacity = 1; // Cambiar a opacidad 1
    }, 10); // Pequeño retraso para aplicar la transición
    updateClientHistoryDisplay();
});

// Función para actualizar el historial de operaciones
function updateHistoryDisplay() {
    historyList.innerHTML = '';
    history.forEach(entry => {
        const li = document.createElement('li');
        li.textContent = entry;
        historyList.appendChild(li);
    });
}

// Función para actualizar el historial de clientes
function updateClientHistoryDisplay() {
    clientHistoryList.innerHTML = '';
    clients.forEach(client => {
        const tr = document.createElement('tr');
        const emailTd = document.createElement('td');
        const dniTd = document.createElement('td');
        emailTd.textContent = client.email;
        dniTd.textContent = client.dni;
        tr.appendChild(emailTd);
        tr.appendChild(dniTd);
        clientHistoryList.appendChild(tr);
    });
}

// Cerrar los modales al presionar la "x"
Array.from(closeModal).forEach(btn => {
    btn.addEventListener('click', () => {
        btn.parentElement.parentElement.style.display = 'none';
    });
});

// Cerrar los modales al hacer clic fuera de ellos
window.addEventListener('click', (event) => {
    if (event.target === historyModal) {
        historyModal.style.display = 'none';
    } else if (event.target === clientHistoryModal) {
        clientHistoryModal.style.display = 'none';
    }
});

/*DEA*/
// Función para obtener los clientes y mostrarlos
async function obtenerClientes() {
    const response = await fetch('https://localhost:5001/api/clientes');

    if (response.ok) {
        const clientes = await response.json();
        mostrarClientes(clientes);
    } else {
        console.error('Error al obtener clientes');
    }
}

// Función para mostrar los clientes en el frontend
function mostrarClientes(clientes) {
    const clienteList = document.getElementById('cliente-list');
    clienteList.innerHTML = ''; // Limpiar la lista antes de agregar nuevos elementos

    clientes.forEach(cliente => {
        const clienteItem = document.createElement('div');
        clienteItem.textContent = `DNI: ${cliente.dni}, Email: ${cliente.email}`;
        clienteList.appendChild(clienteItem);
    });
}

// Función para registrar un nuevo cliente
async function registrarCliente() {
    const dni = document.getElementById('dni-input').value;
    const email = document.getElementById('email-input').value;

    const response = await fetch('https://localhost:5001/api/clientes', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ dni: dni, email: email })
    });

    if (response.ok) {
        console.log('Cliente registrado con éxito');
        // Limpiar los campos de entrada
        document.getElementById('dni-input').value = '';
        document.getElementById('email-input').value = '';
        // Volver a cargar la lista de clientes
        obtenerClientes();
    } else {
        console.error('Error al registrar cliente');
    }
}

// Asignar el evento al botón de registro
document.getElementById('registrar-button').addEventListener('click', registrarCliente);

// Llamar a obtenerClientes al cargar la página
document.addEventListener('DOMContentLoaded', obtenerClientes);


