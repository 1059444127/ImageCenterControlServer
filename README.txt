��Ŀ���ƣ�Ӱ�����Ŀ���ϵͳ�ܿط�����

���ߣ�Jie
���䣺jiejie941102@163.com
ʱ�䣺2017��8��10��

��Ŀ��μܹ���
1.������
AdminControl

2.��̬���ӿ�
LogService
��־��¼����

DataTransferService
���ݴ������

DataHandleService
���ݽ�������

DataBaseService
���ݿ����

3.�ӿ�
DataBaseInterface
���ݿ�ӿ�

NetworkInterface
����ͨѶ�ӿ�

FileHandleInterface
�ļ�����ӿ�

DataHandleInterface
���ݴ���ӿ�

4.��Ŀ������
AdminControl
	->LogService
		->FileHandleInterface
	->DataTransferService
		->NetWorkInterface
	->DataHandleService
		->DataHandleInterface
	->DataBaseService
		->DataBaseInterface



