package jp.co.ginga.domain.service.imp;

import static org.junit.Assert.*;

import java.util.ArrayList;
import java.util.List;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

import jp.co.ginga.domain.entity.UserEntity;
import jp.co.ginga.domain.repository.StubUserRepository;
import jp.co.ginga.domain.repository.UserRepository;

@RunWith(SpringRunner.class)
@SpringBootTest
public class UserServiceImpTest {

	@Autowired
	UserServiceImp userServiceImp;

	//@Ignore
	@Test
	public void getUserListTest_OK_001() {

		/**
		 * テストデータ作成
		 */
		String id = "testId";
		String password = "testPw";
		int permissionLevel = 1;
		String note = "testNt";

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		UserRepository stub = new StubUserRepository() {

			@Override
			public List<UserEntity> findAll() {
				List<UserEntity> userList = new ArrayList<UserEntity>();

				UserEntity user = new UserEntity();
				user.setId(id);
				user.setPassword(password);
				user.setPermissionLevel(permissionLevel);
				user.setNote(note);
				userList.add(user);
				return userList;
			}

		};

		/**
		 * サービスにスタブをセット
		 */
		userServiceImp.setRepoUser(stub);

		/**
		 * セットしたものがゲットできるかのチェック
		 */
		UserRepository test = userServiceImp.getRepoUser();
		System.out.println("RepoUserのテスト -----> " + test);

		/**
		 * テストメソッドの呼び出し
		 */
		List<UserEntity> userList = userServiceImp.getUserList();

		System.out.println("user : findAll OK Test用ユーザ名は -----> "+userList.get(0).getId());

		/**
		 * テストデータとテストメソッドで取得した値が同値かチェック
		 */
		assertEquals(id, userList.get(0).getId());
		assertEquals(password, userList.get(0).getPassword());
		assertEquals(permissionLevel, userList.get(0).getPermissionLevel());
		assertEquals(note, userList.get(0).getNote());
	}
	//@Ignore
	@Test
	public void getUserListTest_NG_001() {

		try {

		/**
		 * レポジトリをスタブでインスタンス生成し、例外をはかせる
		 */
		UserRepository stub = new StubUserRepository() {
			@Override
			public List<UserEntity> findAll() {
				throw new IllegalArgumentException();
			}
		};

		/**
		 * サービスに例外スタブをセット
		 */
		userServiceImp.setRepoUser(stub);

		/**
		 * 例外がキャッチされるはずなのでこちらは通ってはいけない
		 */
		List<UserEntity> userList = userServiceImp.getUserList();
		System.out.println("user : findAll NG fail() -----> " + userList);
		fail();

		}catch (IllegalArgumentException e){
			System.out.println("user : findAll NG 例外名は -----> " + e);
		}
	}
	//@Ignore
	@Test
	public void getUserTest_OK_001(){

		/**
		 * テストデータ作成
		 */
		String id = "testId";
		String password = "testPw";
		int permissionLevel = 1;
		String note = "testNt";

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		UserRepository stub = new StubUserRepository() {
			@Override
			public UserEntity findOneById(String str) {

				UserEntity user = new UserEntity();
				user.setId(id);
				user.setPassword(password);
				user.setPermissionLevel(permissionLevel);
				user.setNote(note);

				return user;
			}
		};

		/**
		 * サービスにスタブをセット
		 */
		userServiceImp.setRepoUser(stub);

		/**
		 * テストメソッドの呼び出し
		 */
		UserEntity user = userServiceImp.getUser(id);

		System.out.println("user : findOne OK Test用ユーザ名は -----> "+user.getId());

		/**
		 * テストデータとテストメソッドで取得した値が同値かチェック
		 */
		assertEquals(id, user.getId());
		assertEquals(password, user.getPassword());
		assertEquals(permissionLevel, user.getPermissionLevel());
		assertEquals(note, user.getNote());
	}
	//@Ignore
	@Test
	public void getUserTest_NG_001() {

		/**
		 * テストデータ作成
		 */
		String id = "testId";

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		UserRepository stub = new StubUserRepository() {
			@Override
			public UserEntity findOneById(String str) {
				UserEntity user = new UserEntity();
				return user;
			}
		};

		/**
		 * サービスにスタブをセット
		 */
		userServiceImp.setRepoUser(stub);

		/**
		 * テストメソッドの呼び出し
		 */
		UserEntity user = userServiceImp.getUser(id);

		System.out.println("user : findOne NG 異常系 Test用ユーザ名は ----->" + user.getId());

		/**
		 * 存在しないユーザー名ではNullが返ってくるはず
		 */
		assertNull(user.getId());
	}
	//@Ignore
	@Test
	public void getUserTest_NG_002() {

		try {

		/**
		 * テストデータ作成
		 */
		String id = "testId";

		/**
		 * レポジトリをスタブでインスタンス生成し、例外をはかせる
		 */
		UserRepository stub = new StubUserRepository() {
			@Override
			public UserEntity findOneById(String str) {
				throw new IllegalArgumentException();
			}
		};

		/**
		 * サービスに例外スタブをセット
		 */
		userServiceImp.setRepoUser(stub);

		/**
		 * 例外がキャッチされるはずなのでこちらは通ってはいけない
		 */
		UserEntity user = userServiceImp.getUser(id);
		System.out.println("user : findAll NG fail() -----> " + user);
		fail();

		}catch (IllegalArgumentException e){
			System.out.println("user : findOne NG 例外系 例外名は -----> " + e);
		}
	}
//	@Ignore
	@Test
	public void deleteTest_OK_001() {

		/**
		 * テストデータ作成
		 */
		String id = "testId";

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		UserRepository stub = new StubUserRepository() {
			@Override
			public boolean delete(String str) {
			return true;
			}
		};
		/**
		 * サービスにスタブをセット
		 */
		userServiceImp.setRepoUser(stub);

		/**
		 * テストメソッドの呼び出し
		 */
		int delete = userServiceImp.delete(id);

		System.out.println("user : delete OK 成功時の値は -----> " + delete);

		assertEquals(1 , delete);
	}
//	@Ignore
	@Test
	public void deleteTest_NG_001() {

		/**
		 * テストデータ作成
		 */
		String id = "testId";

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		UserRepository stub = new StubUserRepository() {
			@Override
			public boolean delete(String str) {
			return false;
			}
		};
		/**
		 * サービスにスタブをセット
		 */
		userServiceImp.setRepoUser(stub);

		/**
		 * テストメソッドの呼び出し
		 */
		int delete = userServiceImp.delete(id);

		System.out.println("user : delete NG 異常系 失敗時の値は -----> " + delete);

		assertEquals(0 , delete);
	}
//	@Ignore
	@Test
	public void deleteTest_NG_002() {

		try {

		/**
		 * テストデータ作成
		 */
		String id = "testId";

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		UserRepository stub = new StubUserRepository() {
			@Override
			public boolean delete(String str) {
				throw new IllegalArgumentException();
			}
		};
		/**
		 * サービスにスタブをセット
		 */
		userServiceImp.setRepoUser(stub);

		/**
		 * 例外がキャッチされるはずなのでこちらは通ってはいけない
		 */
		int delete = userServiceImp.delete(id);
		System.out.println("user : delete NG 例外系 fail() -----> " + delete);
		fail();

		}catch(IllegalArgumentException e){
			System.out.println("user : delete NG 例外系 例外名は -----> " + e);
		}
	}
//	@Ignore
	@Test
	public void updateTest_OK_001() {

		/**
		 * テストデータの作成
		 */
		UserEntity user = new UserEntity();

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		UserRepository stub = new StubUserRepository() {
			@Override
			public boolean update(UserEntity user) {
			return true;
			}
		};
		/**
		 * サービスにスタブをセット
		 */
		userServiceImp.setRepoUser(stub);

		/**
		 * テストメソッドの呼び出し
		 */
		int update = userServiceImp.update(user);

		System.out.println("user : update OK 成功時の値は -----> " + update);

		assertEquals(1 , update);
	}
//	@Ignore
	@Test
	public void updateTest_NG_001() {

		/**
		 * テストデータ作成
		 */
		UserEntity user = new UserEntity();

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		UserRepository stub = new StubUserRepository() {
			@Override
			public boolean update(UserEntity user) {
			return false;
			}
		};
		/**
		 * サービスにスタブをセット
		 */
		userServiceImp.setRepoUser(stub);

		/**
		 * テストメソッドの呼び出し
		 */
		int update = userServiceImp.update(user);

		System.out.println("user : update NG 異常系 失敗時の値は -----> " + update);

		assertEquals(0 , update);
	}
//	@Ignore
	@Test
	public void updateTest_NG_002() {

		try {

		/**
		 * テストデータ作成
		 */
			UserEntity user = new UserEntity();

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		UserRepository stub = new StubUserRepository() {
			@Override
			public boolean update(UserEntity user) {
				throw new IllegalArgumentException();
			}
		};
		/**
		 * サービスにスタブをセット
		 */
		userServiceImp.setRepoUser(stub);

		/**
		 * 例外がキャッチされるはずなのでこちらは通ってはいけない
		 */
		int update = userServiceImp.update(user);
		System.out.println("user : update NG 例外系 fail() -----> " + update);
		fail();

		}catch(IllegalArgumentException e){
			System.out.println("user : update NG 例外系 例外名は -----> " + e);
		}
	}
//	@Ignore
	@Test
	public void addTest_OK_001() {

		/**
		 * テストデータの作成
		 */
		UserEntity user = new UserEntity();

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		UserRepository stub = new StubUserRepository() {
			@Override
			public boolean add(UserEntity user) {
			return true;
			}
		};
		/**
		 * サービスにスタブをセット
		 */
		userServiceImp.setRepoUser(stub);

		/**
		 * テストメソッドの呼び出し
		 */
		int add = userServiceImp.add(user);

		System.out.println("user : add OK 成功時の値は -----> " + add);

		assertEquals(1 , add);
	}
//	@Ignore
	@Test
	public void addTest_NG_001() {

		/**
		 * テストデータ作成
		 */
		UserEntity user = new UserEntity();

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		UserRepository stub = new StubUserRepository() {
			@Override
			public boolean add(UserEntity user) {
			return false;
			}
		};
		/**
		 * サービスにスタブをセット
		 */
		userServiceImp.setRepoUser(stub);

		/**
		 * テストメソッドの呼び出し
		 */
		int add = userServiceImp.add(user);

		System.out.println("user : add NG 異常系 失敗時の値は -----> " + add);

		assertEquals(0 , add);
	}
//	@Ignore
	@Test
	public void addTest_NG_002() {

		try {

		/**
		 * テストデータ作成
		 */
			UserEntity user = new UserEntity();

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		UserRepository stub = new StubUserRepository() {

			@Override
			public boolean add(UserEntity user) {
				// TODO 自動生成されたメソッド・スタブ
				throw new IllegalArgumentException();
			}
//			@Override
//			public boolean add(UserEntity user) {
//				throw new IllegalArgumentException();
//			}
		};
		/**
		 * サービスにスタブをセット
		 */
		userServiceImp.setRepoUser(stub);

		/**
		 * 例外がキャッチされるはずなのでこちらは通ってはいけない
		 */
		int add = userServiceImp.add(user);
		System.out.println("user : add NG 例外系 fail() -----> " + add);
		fail();

		}catch(IllegalArgumentException e){
			System.out.println("user : add NG 例外系 例外名は -----> " + e);
		}
	}
}