$(document).ready(function(){

	
	
	$("#lcpf").click(function(){
		
		var veriCpf = $('input:checkbox[id=cpf]').is(':checked')
		var veriCnpj = $('input:checkbox[id=cnpj]').is(':checked')
		
		if(veriCpf){
			$("#cnpj").prop('checked',false)
			$("#CPFCNPJ").text("CPF: ")
			$("#TCPF").attr('onkeyup','formataCPF(this,event)')
			$("#TCPF").val("");
			$("#CPFCNPJ").show()
			$("#TCPF").show()
			$("#ano").show()
			$("#DropList").show()
			$("#submit").show()
			
		}else if (!veriCpf && !veriCnpj){
			$("#CPFCNPJ").hide()
			$("#TCPF").hide()
			$("#ano").hide()
			$("#DropList").hide()
			$("#submit").hide()
		}
		
	});
	
	$("#lcnpj").click(function(){
		
		var veriCnpj = $('input:checkbox[id=cnpj]').is(':checked')
		var veriCpf = $('input:checkbox[id=cpf]').is(':checked')
		
		if(veriCnpj){
			$("#cpf").prop('checked',false)
			$("#CPFCNPJ").text("CNPJ: ")
			$("#TCPF").attr('onkeyup','formataCNPJ(this,event)')
			$("#TCPF").val("");
			$("#CPFCNPJ").show()
			$("#TCPF").show()
			$("#ano").show()
			$("#DropList").show()
			$("#CPFCNPJ").show()
			$("#submit").show()
			
		}else if (!veriCpf && !veriCnpj){
			$("#CPFCNPJ").hide()
			$("#TCPF").hide()
			$("#ano").hide()
			$("#DropList").hide()
			$("#submit").hide()
		}
		
	});
});
