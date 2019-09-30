package jp.co.ginga.security;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.AuthorityUtils;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.User;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Service;

import jp.co.ginga.domain.entity.UserEntity;
import jp.co.ginga.domain.service.UserService;

@Service
public class UserDetailServiceImp implements UserDetailsService {

	@Autowired
	UserService service;

	@Override
	public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {

		UserEntity user = service.getUser(username);
		System.out.println("Service intercept");
		if (user == null) {
			throw new UsernameNotFoundException("User" + username + "was not found in the database");
		}
		// 権限のリスト
		// AdminやUserなどが存在するが、今回は利用しないのでUSERのみを仮で設定
		// 権限を利用する場合は、DB上で権限テーブル、ユーザ権限テーブルを作成し管理が必要
		List<GrantedAuthority> grantList = new ArrayList<GrantedAuthority>();
		GrantedAuthority authority;
		if (user.getPermissionLevel() == 1) {
			authority = new SimpleGrantedAuthority("ADMIN");
			System.out.println("ADMIN");
		} else {
			authority = new SimpleGrantedAuthority("USER");
			System.out.println("USER");
		}

		grantList.add(authority);

		// rawDataのパスワードは渡すことができないので、暗号化
		BCryptPasswordEncoder encoder = new BCryptPasswordEncoder();

		// UserDetailsはインタフェースなのでUserクラスのコンストラクタで生成したユーザオブジェクトをキャスト
		UserDetails userDetails = (UserDetails) new User(user.getId(), encoder.encode(user.getPassword()),
				getAuthorities(user));

		System.out.println("userDetails : " + userDetails.getUsername() + userDetails.getPassword());
		return userDetails;
	}

	private Collection<GrantedAuthority> getAuthorities(UserEntity user) {
		if (user.getPermissionLevel() == 1) {
			return AuthorityUtils.createAuthorityList("ROLE_USER", "ROLE_ADMIN");
		} else {
			return AuthorityUtils.createAuthorityList("ROLE_USER");
		}

	}

}
