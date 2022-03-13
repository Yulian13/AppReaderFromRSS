function deleteOldStepRadio() {
	DivStepsRadio.innerHTML = '';
}

function renderStepRadio(numberStep) {
	for (let step = 0; step < numberStep; step++) {
		const id = "step" + step;

		var radio = document.createElement("input");
		radio.setAttribute("type", "radio");
		radio.setAttribute("name", "step");
		radio.setAttribute("id", id);
		radio.setAttribute("value", step);
		radio.setAttribute("onclick", `GetNewsCollection(${step})`);
		radio.checked = (step == 0);

		var labelRadio = document.createElement("label");
		labelRadio.setAttribute("for", id);
		labelRadio.innerText = step + 1;

		var divRadio = document.createElement("div");
		divRadio.setAttribute("class", "radioStep");

		divRadio.appendChild(radio);
		divRadio.appendChild(labelRadio);

		DivStepsRadio.appendChild(divRadio);
	}
}