===================================================================================================================================================
option1:	run RabbiMQ on local mmachine 
			see:	google:		marco behler rabbitmq
					setup		https://www.youtube.com/watch?v=oRIF1xKEI0I 
					sending		https://www.youtube.com/watch?v=gaLmPqrm5LI
					subscribe	https://www.youtube.com/watch?v=BS7tY-Exo0w
					see messages of  a queue			https://www.youtube.com/watch?v=2SE9w1XfevA


			in the end:
			windows service RabbitMQ
			web interface:  http://localhost:15672/		username: guest		password: guest
===================================================================================================================================================

https://www.rabbitmq.com/		=>	download + installation			=> https://www.rabbitmq.com/install-windows.html	=> using the installer 


step1: instal Erolang 64 bit					https://erlang.org/download/otp_versions_tree.html
												otp_win64_23.0


step2:	download and intstall  rabbbitmq-server	https://www.rabbitmq.com/install-windows.html#installer
		it installed windows service rabbitmmq

step3:	see that the windows service is installed
		RabbitMQ 

step4:	see some batch utils
		dir C:\Program Files\RabbitMQ Server\rabbitmq_server-3.8.7\sbin\*.bat

			rabbitmq-plugins.bat
			rabbitmq-server.bat
			rabbitmq-service.bat     stop		- stopes the rabbitmq windows service
			rabbitmq-service.bat     start      - starts the rabbitmq winsows service
			rabbitmqctl.bat          status     - gets the process id
				                                  gets the listiners to see that rabbitmq is litening with amqp proptcol pn port 5672
		                                      
step5:	enable the rabbit mq web interface
		cd c:\Program Files\RabbitMQ Server\rabbitmq_server-3.8.7\sbin\
		rabbitmq-plugins enable rabbitmq_management

		note: if you run "rabbitmqctl.bat          status" now, then in the listeners you will now see http listeners


step6:	open the rabbitmq web interface
		http://localhost:15672/
		username:	guest
		password:	guest

===================================================================================================================================================


