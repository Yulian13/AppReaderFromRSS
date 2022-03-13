const Selector = document.getElementById("sourceSelect");
const DivStepsRadio = document.getElementById("divStepsRadio");
const ViewTable = document.getElementById("viewTable");
var RequestBody = {
	source:		"",
	orderBy:	"",
	step:		0,
};

function reRenderPageWithData() {
	initRequestBody();
	GetNewsCollection();
	reRenderStepRadio();
}

function initRequestBody() {
	RequestBody.source = Selector.value;
	RequestBody.orderBy = getOrderBy();
	RequestBody.step = 0;
}

function getOrderBy() {
	return document.querySelector('input[name="OrderBy"]:checked').value;
}

function GetNewsCollection(step) {
	RequestBody.step = step;
	const body = JSON.stringify(
		RequestBody
	);
	SendAPIRequest('POST', 'GetNewsCollectionByParametr', body, function (httpRequest) {
		const newsColection = JSON.parse(httpRequest.responseText);
		clearTable();
		renderTable(newsColection);
		window.scrollTo({
			top: 0,
			behavior: "smooth"
		});
	});
}

function reRenderStepRadio() {
	const body = JSON.stringify({
		source: RequestBody.source
	});
	SendAPIRequest('POST', 'GetNumberStep', body, function (httpRequest) {
		const stepNumber = JSON.parse(httpRequest.responseText);
		deleteOldStepRadio();
		renderStepRadio(stepNumber);
	});
}

function SendAPIRequest(method, action, body, callback) {
	var httpRequest = new XMLHttpRequest();
	httpRequest.open(method, '/api/ViewData/' + action, true);
	httpRequest.setRequestHeader("Content-Type", "application/json");
	httpRequest.onload = () => {
		if (httpRequest.status == 200) {
			callback(httpRequest);
		}
	}

	httpRequest.send(body);
}

