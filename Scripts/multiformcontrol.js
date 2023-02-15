const DOMstrings = {
    stepsBtnClass: 'multisteps-form__progress-btn',
    stepsBtns: document.querySelectorAll('.multisteps-form__progress-btn'),
    stepsBar: document.querySelector('.multisteps-form__progress'),
    stepsForm: document.querySelector('.multisteps-form__form'),
    stepsFormTextareas: document.querySelectorAll('.multisteps-form__textarea'),
    stepFormPanelClass: 'multisteps-form__panel',
    stepFormPanels: document.querySelectorAll('.multisteps-form__panel'),
    stepPrevBtnClass: 'js-btn-prev',
    stepNextBtnClass: 'js-btn-next',
    regNextBtn: document.querySelector('.btnIdenti'),
    regSubmit: document.querySelector('.regBtnSubmit')
};


const campos = {
    regDocumentType: false,
    regIdentiNumber: false,
    regFname: false,
    regSname: false,
    regFlname: false,
    regSlname: false,
    regUbirth: false,
    regEmail: false,
    regCel: false,
    regDirect: false,
    regPass: false

};

const expresiones = {
    nombreOapllido: /^[a-zA-ZÀ-ÿ\s]{1,40}$/, // Letras y espacios, pueden llevar acentos.
    password: /^[a-zA-Z0-9\_\-\@\*]{8,16}$/, // 4 a 12 digitos.
    date: /^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$/,
    correo: /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/,
    telefono: /([1-9]|6[0-9])[0-9]{2}[0-9]{4}$/,// 7 a 14 numeros.
    identificacion: /^ P$ |^ (?: PE | E | N | [23456789] | [23456789](?: A | P) ?| 1[0123] ?| 1[0123] ? (?: A | P) ?)$|^ (?: PE | E | N | [23456789] | [23456789](?: AV | PI) ?| 1[0123] ?| 1[0123] ? (?: AV | PI) ?) -? $ |^ (?: PE | E | N | [23456789](?: AV | PI) ?| 1[0123] ? (?: AV | PI) ?) - (?: \d{ 1, 4 }) -? $ |^ (PE | E | N | [23456789](?: AV | PI) ?| 1[0123] ? (?: AV | PI) ?) - (\d{ 1, 4 }) -(\d{ 1, 6 }) $ /,
    cedula: /^P$|^(?:PE|E|N|[23456789]|[23456789](?:A|P)?|1[0123]?|1[0123]?(?:A|P)?)$|^(?:PE|E|N|[23456789]|[23456789](?:AV|PI)?|1[0123]?|1[0123]?(?:AV|PI)?)-?$|^(?:PE|E|N|[23456789](?:AV|PI)?|1[0123]?(?:AV|PI)?)-(?:\d{1,4})-?$|^(PE|E|N|[23456789](?:AV|PI)?|1[0123]?(?:AV|PI)?)-(\d{1,4})-(\d{1,6})$/,
    pasaporte: /^[a-zA-Z0-9 ]{6,30}$/
};

const formulario = document.getElementById('form1');
const inputs = document.querySelectorAll('#form1 input');
const select = document.querySelectorAll('#form1 select');
const botones = document.querySelectorAll("#form1 .spin");


const agregarSpin = (e) => {
    const padre = e.target;
    const NewSpin = document.createElement("div");
    NewSpin.setAttribute("class", "spinner-border spinner-border-sm ms-1");
    NewSpin.setAttribute("role", "status");
    padre.classList.add("disabled");

    padre.textContent = "Cargando..."
    padre.appendChild(NewSpin);

}


const validarFormulario = (e) => {

    switch (e.target.name) {
        case "ctl00$ContentPlaceHolder1$regDocumentType":
            validarSelect(e.target);
            break;

        case "ctl00$ContentPlaceHolder1$regIdentiNumber":
            validarCampo(expresiones.identificacion, e.target, "regIdentiNumber");
            break;
        case "ctl00$ContentPlaceHolder1$regFname":
            validarCampo(expresiones.nombreOapllido, e.target, "regFname");
            break;
        case "ctl00$ContentPlaceHolder1$regSname":
            validarCampo(expresiones.nombreOapllido, e.target, "regSname");
            break;
        case "ctl00$ContentPlaceHolder1$regFlname":
            validarCampo(expresiones.nombreOapllido, e.target, "regFlname");
            break;
        case "ctl00$ContentPlaceHolder1$regSlname":
            validarCampo(expresiones.nombreOapllido, e.target, "regSlname");
            break;
        case "ctl00$ContentPlaceHolder1$regUbirth":
            validarCampo(expresiones.date, e.target, "regUbirth");
            break;
        case "ctl00$ContentPlaceHolder1$regCel":
            validarCampo(expresiones.telefono, e.target, "regCel");
            break;
        case "ctl00$ContentPlaceHolder1$regEmail":
            validarCampo(expresiones.correo, e.target, "regEmail");
            break;
        case "ctl00$ContentPlaceHolder1$regPass":
            validarCampo(expresiones.password, e.target, 'regPass');
            validarPassword2();
            break;
        case "ctl00$ContentPlaceHolder1$regRPass":
            validarPassword2();
            break;
        case "ctl00$ContentPlaceHolder1$regCheckDeclaration":
            if (e.target.checked && campos.password == true) {
                
                document.querySelector(`.regBtnSubmit`).classList.remove('disabled');

            } else {
                
                document.querySelector(`.regBtnSubmit`).classList.add('disabled');
            }
            break;
    }
}


const direct = document.querySelector('.regDirect');
direct.addEventListener('keyup', e => {
    if (e.target.value.length > 10) {
        e.target.classList.add("is-valid");
        campos["regDirect"] = true;
        /*valNext(campos.regDirect, 'btnContact');*/
    } else {
        e.target.classList.remove("is-valid");
        campos["regDirect"] = false;
    }
});



const validarSelect = (select) => {
    const numeroident = document.querySelector('.regIdentiNumber');
    switch (select.value) {
        case 'Cédula':
            
            select.classList.add("is-valid");
            expresiones.identificacion = expresiones.cedula;
            numeroident.removeAttribute('disabled');
            campos["regDocumentType"] = true;
            break;
        case 'Pasaporte':
            
            select.classList.add("is-valid");
            expresiones.identificacion = expresiones.pasaporte;
            numeroident.removeAttribute('disabled');
            campos["regDocumentType"] = true;
            break;
        case 'Seleccione documento':
            
            select.classList.remove("is-valid");
            campos["regDocumentType"] = false;
            numeroident.setAttribute('disabled', true);
            expresiones.identificacion = expresiones.cedula;
            break;
    }
}

const validarPassword2 = () => {
    const inputPassword1 = document.querySelector('.regPass');
    const inputPassword2 = document.querySelector('.regRPass');
    const check = document.querySelector('#ContentPlaceHolder1_regCheckDeclaration');



    var letter = document.querySelector('.passLower');
    var capital = document.querySelector('.passUpper');
    var number = document.querySelector('.passNumber');
    var length = document.querySelector('.passMin');
    var caracterespecial = document.querySelector('.passSpecial');

    var lowerCaseLetters = /[a-z]/g;
    if (inputPassword1.value.match(lowerCaseLetters)) {
        letter.classList.remove("text-danger");
        letter.classList.add("text-success");
    } else {
        letter.classList.remove("text-success");
        letter.classList.add("text-danger");
    }


    // Validate special character
    var especial = /[\_\-\@\*]/g;
    if (inputPassword1.value.match(especial)) {
        caracterespecial.classList.remove("text-danger");
        caracterespecial.classList.add("text-success");
    } else {
        caracterespecial.classList.remove("text-success");
        caracterespecial.classList.add("text-danger");
    }

    // Validate capital letters
    var upperCaseLetters = /[A-Z]/g;
    if (inputPassword1.value.match(upperCaseLetters)) {
        capital.classList.remove("text-danger");
        capital.classList.add("text-success");
    } else {
        capital.classList.remove("text-success");
        capital.classList.add("text-danger");
    }

    // Validate numbers
    var numbers = /[0-9]/g;
    if (inputPassword1.value.match(numbers)) {
        number.classList.remove("text-danger");
        number.classList.add("text-success");
    } else {
        number.classList.remove("text-success");
        number.classList.add("text-danger");
    }

    // Validate length
    if (inputPassword1.value.length >= 8 ) {
        length.classList.remove("text-danger");
        length.classList.add("text-success");
    } else {
        length.classList.remove("text-success");
        length.classList.add("text-danger");
    }


    if (inputPassword1.value.length < 3 || inputPassword1.value !== inputPassword2.value) {
        inputPassword2.classList.remove('is-valid');
        inputPassword2.classList.add('is-invalid');
        campos['password'] = false;
    } else {
        inputPassword2.classList.add('is-valid');
        inputPassword2.classList.remove('is-invalid');
        
        check.removeAttribute('disabled');
        campos['password'] = true;

    }
}

const validarCampo = (expresion, input, campo) => {
    if (expresion.test(input.value)) {
        document.querySelector(`.${campo}`).classList.add('is-valid');
        document.querySelector(`.${campo}`).classList.remove('is-invalid');
        campos[campo] = true;

    } else {
        document.querySelector(`.${campo}`).classList.remove('is-valid');
        document.querySelector(`.${campo}`).classList.add('is-invalid');
        campos[campo] = false;
    }
};

inputs.forEach((input) => {
    input.addEventListener('keyup', validarFormulario);
    input.addEventListener('blur', validarFormulario);
    input.addEventListener('change', validarFormulario);
});
select.forEach((select) => {
    select.addEventListener('click', validarFormulario);
    select.addEventListener('blur', validarFormulario);
    select.addEventListener('change', validarFormulario);
    select.addEventListener('load', validarFormulario);
});
botones.forEach((boton) => {
    boton.addEventListener('click', agregarSpin);

});

const removeClasses = (elemSet, className) => {

    elemSet.forEach(elem => {

        elem.classList.remove(className);

    });

};

const findParent = (elem, parentClass) => {

    let currentNode = elem;

    while (!currentNode.classList.contains(parentClass)) {
        currentNode = currentNode.parentNode;
    }

    return currentNode;

};

const getActiveStep = elem => {
    return Array.from(DOMstrings.stepsBtns).indexOf(elem);
};

const setActiveStep = activeStepNum => {

    removeClasses(DOMstrings.stepsBtns, 'js-active');

    DOMstrings.stepsBtns.forEach((elem, index) => {

        if (index <= activeStepNum) {
            elem.classList.add('js-active');
        }

    });
};

const getActivePanel = () => {

    let activePanel;

    DOMstrings.stepFormPanels.forEach(elem => {

        if (elem.classList.contains('js-active')) {

            activePanel = elem;

        }

    });

    return activePanel;

};

const setActivePanel = activePanelNum => {

    removeClasses(DOMstrings.stepFormPanels, 'js-active');

    DOMstrings.stepFormPanels.forEach((elem, index) => {
        if (index === activePanelNum) {

            elem.classList.add('js-active');

            setFormHeight(elem);

        }
    });

};

const formHeight = activePanel => {

    const activePanelHeight = activePanel.offsetHeight;

    DOMstrings.stepsForm.style.height = `${activePanelHeight}px`;

};

const setFormHeight = () => {
    const activePanel = getActivePanel();

    formHeight(activePanel);
};


DOMstrings.stepsForm.addEventListener('click', e => {

    const eventTarget = e.target;

    if (!(eventTarget.classList.contains(`${DOMstrings.stepPrevBtnClass}`) || eventTarget.classList.contains(`${DOMstrings.stepNextBtnClass}`))) {
        return;
    }

    const activePanel = findParent(eventTarget, `${DOMstrings.stepFormPanelClass}`);

    let activePanelNum = Array.from(DOMstrings.stepFormPanels).indexOf(activePanel);

    if (eventTarget.classList.contains(`${DOMstrings.stepPrevBtnClass}`)) {
        activePanelNum--;

    } else {

        activePanelNum++;

    }

    setActiveStep(activePanelNum);
    setActivePanel(activePanelNum);

});

window.addEventListener('load', setFormHeight, false);

window.addEventListener('resize', setFormHeight, false);





