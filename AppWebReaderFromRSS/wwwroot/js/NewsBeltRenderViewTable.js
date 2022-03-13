function clearTable() {
	do {
		var trDom = document.querySelector('tr[isDelete="true"]');

		var domIsEmpty = !Boolean(trDom);
		if (domIsEmpty) {
			break;
		}

		trDom.remove();
	}
	while (true)
}

function renderTable(newsColection) {
	newsColection.forEach(function (news) {
		var trDom = document.createElement("tr");
		trDom.setAttribute("isDelete", "true");

		appendTdSourse(trDom, news.newsSourсeId);
		appendTdTitle(trDom, news.title, news.urlLink);
		appendTdDescription(trDom, news.description);
		appendTdPublicationDate(trDom, news.publicationDate);

		ViewTable.appendChild(trDom);
	})
}

function appendTdSourse(trDom, sourse) {
	var tdDom = document.createElement("td");
	var spanDom = document.createElement("span");
	spanDom.innerText = sourse;
	tdDom.appendChild(spanDom);
	trDom.appendChild(tdDom);
}

function appendTdTitle(trDom, title, link) {
	var tdDom = document.createElement("td");
	var aDom = document.createElement("a");
	aDom.setAttribute("href", link);
	aDom.innerText = title;
	tdDom.appendChild(aDom);
	trDom.appendChild(tdDom);
}

function appendTdDescription(trDom, description) {
	var tdDom = document.createElement("td");
	var spanDom = document.createElement("span");
	spanDom.innerHTML = description;
	tdDom.appendChild(spanDom);
	trDom.appendChild(tdDom);
}

function appendTdPublicationDate(trDom, date) {
	var tdDom = document.createElement("td");
	var spanDom = document.createElement("span");

	spanDom.innerText = date;
	tdDom.appendChild(spanDom);
	trDom.appendChild(tdDom);
}