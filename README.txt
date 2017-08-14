项目名称：影像中心控制系统总控服务器

作者：Jie
邮箱：jiejie941102@163.com
时间：2017年8月10日

项目层次架构：
1.主程序
AdminControl

2.动态链接库
LogService
日志记录服务

DataTransferService
数据传输服务

DataHandleService
数据解析服务

DataBaseService
数据库服务

3.接口
DataBaseInterface
数据库接口

NetworkInterface
网络通讯接口

FileHandleInterface
文件处理接口

DataHandleInterface
数据处理接口

4.项目依赖项
AdminControl
	->LogService
		->FileHandleInterface
	->DataTransferService
		->NetWorkInterface
	->DataHandleService
		->DataHandleInterface
	->DataBaseService
		->DataBaseInterface



