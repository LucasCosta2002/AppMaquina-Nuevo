window.GenerarPDF = async (trabajo, maquinista, cliente) => {

	var pdf = new jsPDF();

	//colores
	var bgGreen = [66, 139, 87];

	//fuentes
	pdf.setFontSize(18);
	pdf.setFont("helvetica", "normal");

	//encabezado verde
	pdf.setTextColor(bgGreen[0], bgGreen[1], bgGreen[2]);
	pdf.text(20, 20, "Resumen de trabajo", null, true);

	//línea verde
	pdf.setLineWidth(2);
	pdf.setDrawColor(bgGreen[0], bgGreen[1], bgGreen[2]);
	pdf.line(10, 40, 200, 40);

	// colores de texto
	pdf.setTextColor(0, 0, 0); // Color de texto negro

	// datos del trabajo
	pdf.setFontSize(12);
	pdf.text(20, 50, "Cliente:", null, true);
	pdf.text(50, 50, cliente.nombre, null, true);

	pdf.text(20, 60, "Maquinista:", null, true);
	pdf.text(50, 60, maquinista.nombre, null, true);

	pdf.text(20, 70, "Fecha:", null, true);
	pdf.text(50, 70, trabajo.fecha, null, true);

	pdf.text(20, 80, "Hectareas:", null, true);
	pdf.text(50, 80, trabajo.hectareas.toString(), null, true);

	pdf.text(20, 90, "Agroquímico:", null, true);
	pdf.text(50, 90, trabajo.agroquimico, null, true);

	pdf.text(20, 100, "Ubicación:", null, true);
	pdf.text(50, 100, trabajo.ubicacion, null, true);

	// Guardar el documento PDF
	pdf.save(`trabajo_${trabajo.fecha}.pdf`);
}