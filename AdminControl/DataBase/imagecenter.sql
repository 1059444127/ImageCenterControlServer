/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 50718
Source Host           : localhost:3306
Source Database       : imagecenter

Target Server Type    : MYSQL
Target Server Version : 50718
File Encoding         : 65001

Date: 2017-08-21 16:26:57
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `tb_clientinformation`
-- ----------------------------
DROP TABLE IF EXISTS `tb_clientinformation`;
CREATE TABLE `tb_clientinformation` (
  `client_id` int(10) NOT NULL AUTO_INCREMENT,
  `client_name` varchar(50) NOT NULL,
  `client_ip` varchar(30) NOT NULL,
  `client_status` varchar(30) NOT NULL,
  PRIMARY KEY (`client_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tb_clientinformation
-- ----------------------------
INSERT INTO `tb_clientinformation` VALUES ('1', '会诊室1客户端', '192.168.31.112', 'Offline');
INSERT INTO `tb_clientinformation` VALUES ('2', '会诊室1控制器 ', '192.168.31.249', 'Online');
INSERT INTO `tb_clientinformation` VALUES ('3', '会诊室2客户端', '192.168.31.102', 'Offline');
INSERT INTO `tb_clientinformation` VALUES ('4', '会诊室2控制器', '192.168.31.103', 'Offline');
INSERT INTO `tb_clientinformation` VALUES ('5', '阅片室1客户端', '192.168.31.250', 'Online');
INSERT INTO `tb_clientinformation` VALUES ('6', '阅片室1控制器', '192.168.31.249', 'Online');
INSERT INTO `tb_clientinformation` VALUES ('7', '阅片室2客户端', '192.168.31.106', 'Offline');
INSERT INTO `tb_clientinformation` VALUES ('8', '阅片室2控制器', '192.168.31.107', 'Offline');

-- ----------------------------
-- Table structure for `tb_devicestatus`
-- ----------------------------
DROP TABLE IF EXISTS `tb_devicestatus`;
CREATE TABLE `tb_devicestatus` (
  `device_id` int(10) NOT NULL AUTO_INCREMENT,
  `device_name` varchar(50) NOT NULL,
  `device_power` int(1) NOT NULL,
  PRIMARY KEY (`device_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tb_devicestatus
-- ----------------------------
INSERT INTO `tb_devicestatus` VALUES ('1', '投影机1', '0');
INSERT INTO `tb_devicestatus` VALUES ('2', '投影机2', '0');
INSERT INTO `tb_devicestatus` VALUES ('3', '胶片镜头', '0');

-- ----------------------------
-- Table structure for `tb_roomenviroument`
-- ----------------------------
DROP TABLE IF EXISTS `tb_roomenviroument`;
CREATE TABLE `tb_roomenviroument` (
  `room_id` int(10) NOT NULL AUTO_INCREMENT,
  `room_name` varchar(50) NOT NULL,
  `room_temp` varchar(50) DEFAULT NULL,
  `room_hum` varchar(50) DEFAULT NULL,
  `room_light` varchar(50) DEFAULT NULL,
  `room_noise` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`room_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tb_roomenviroument
-- ----------------------------
INSERT INTO `tb_roomenviroument` VALUES ('1', '会诊室1', null, null, null, null);
INSERT INTO `tb_roomenviroument` VALUES ('2', '会诊室2', null, null, null, null);
INSERT INTO `tb_roomenviroument` VALUES ('3', '阅片室1', '26.3', '43.3', '126', '54');
INSERT INTO `tb_roomenviroument` VALUES ('4', '阅片室2', null, null, null, null);

-- ----------------------------
-- Table structure for `tb_userinformation`
-- ----------------------------
DROP TABLE IF EXISTS `tb_userinformation`;
CREATE TABLE `tb_userinformation` (
  `user_id` int(10) NOT NULL AUTO_INCREMENT,
  `user_name` varchar(50) NOT NULL,
  `user_passwd` varchar(50) NOT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tb_userinformation
-- ----------------------------
INSERT INTO `tb_userinformation` VALUES ('1', 'Admin', '77113AD328822893C6CF396311A6EE2F');
